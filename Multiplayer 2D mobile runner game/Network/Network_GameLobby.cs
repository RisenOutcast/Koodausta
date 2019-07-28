using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PhotonHashTable = ExitGames.Client.Photon.Hashtable;
using System.Linq;
using TMPro;
using UnityEngine.UI;

//Author: M.J.Metsola @RisenOutcast

namespace RO.Network
{
    public class Network_GameLobby : MonoBehaviourPunCallbacks​
    {
        //Our player name
        string playerName = "Player 1";
        //Users are separated from each other by gameversion (which allows you to make breaking changes).
        string gameVersion = "0.9";
        //The list of created rooms
        List<RoomInfo> createdRooms = new List<RoomInfo>();
        //Use this name when creating a Room
        string roomName = "Room 1";
        Vector2 roomListScroll = Vector2.zero;

        public bool isMaster;

        public TMP_Text PlayerJoinedText;
        public TMP_Text ConnectingText;
        public GameObject roleCanvas;
        public Button _startButton;

        public Player otherPlayer;

        bool lookingForOpponent = false;
        bool readyTostart = false;

        public TMP_Text RunnerName;
        public TMP_Text OverlordName;

        Pelisäätäjä _peliSäätäjä;

        // Use this for initialization
        void Start()
        {
            if (_peliSäätäjä == null)
                _peliSäätäjä = GameObject.FindWithTag("Pelisäätäjä").GetComponent<Pelisäätäjä>();

            //This makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
            playerName = ("Player#" + RandomNumberString(12).ToString());

            if (!PhotonNetwork.IsConnected)
            {
                //Set the App version before connecting
                PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = gameVersion;
                // Connect to the photon master-server. We use the settings saved in PhotonServerSettings (a .asset file in this project)
                PhotonNetwork.SendRate = 20;
                PhotonNetwork.SerializationRate = 20;
                PhotonNetwork.ConnectUsingSettings();
            }
            AddCustoms(PhotonNetwork.LocalPlayer, 0);
            Debug.Log("LocalPlayer isRunner = " + PhotonNetwork.LocalPlayer.CustomProperties["isRunner"].ToString());
        }

        void AddCustoms(Player player, int isRunnerOneOrZero) //Add a custom attribute to player to see if they control the runner or the world(?)
        {
            PhotonHashTable setRole = new PhotonHashTable();
            setRole.Add("isRunner", isRunnerOneOrZero);
            player.SetCustomProperties(setRole);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + cause.ToString() + " ServerAddress: " + PhotonNetwork.ServerAddress);
        }

        public override void OnConnectedToMaster()
        {
            _startButton.interactable = true;
            Debug.Log("OnConnectedToMaster");
            //After we connected to Master server, join the Lobby
            PhotonNetwork.JoinLobby(TypedLobby.Default);
            ConnectingText.text = "Connected!";
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("We have received the Room list");
            //After this callback, update the room list
            createdRooms = roomList;
        }



        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log("OnCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.Log("OnJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("OnJoinRandomFailed got called. This can happen if the room is not existing or full or closed.");

            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = (byte)2; //Set number of allowed players
            roomName = RandomString(256);
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("OnCreatedRoom");
            //Set our player name
            PhotonNetwork.NickName = playerName;
            isMaster = true;

            //PhotonNetwork.LoadLevel("Character");
        }

        public void StartButton()
        {

            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = (byte)2; //Set number of allowed players

            PhotonNetwork.NickName = playerName;
            PhotonNetwork.JoinRandomRoom();
            ConnectingText.text = "Looking for player...";
            lookingForOpponent = true;
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("OnJoinedRoom");
            //roleCanvas.SetActive(true);
            StartCoroutine(StartingGame());
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            Debug.Log("Player Joined!");
            PlayerJoinedText.color = new Color32(0, 255, 0, 255);
            PlayerJoinedText.text = (newPlayer.NickName.ToString() + " joined!");
            ConnectingText.text = "Starting game!";
            int isRunnerOneOrZero = Random.Range(0, 2);
            if (isRunnerOneOrZero == 1)
            {
                AddCustoms(PhotonNetwork.LocalPlayer, 0);
                AddCustoms(newPlayer, 1);
                _peliSäätäjä.Runner = newPlayer;
                _peliSäätäjä.Overlord = PhotonNetwork.LocalPlayer;
                _peliSäätäjä.isOverlord = true;
            }
            else
            {
                AddCustoms(PhotonNetwork.LocalPlayer, 1);
                AddCustoms(newPlayer, 0);
                _peliSäätäjä.Overlord = newPlayer;
                _peliSäätäjä.Runner = PhotonNetwork.LocalPlayer;
                _peliSäätäjä.isOverlord = false;
            }
            otherPlayer = newPlayer;
            Debug.Log("newPlayer isRunner = " + newPlayer.CustomProperties["isRunner"].ToString());
            lookingForOpponent = false;
            readyTostart = true;
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            Debug.Log("Player left.");
            PlayerJoinedText.color = new Color32(255, 0, 0, 255);
            PlayerJoinedText.text = (otherPlayer.NickName.ToString() + " left.");
            ConnectingText.text = "Looking for player...";
            readyTostart = false;
            lookingForOpponent = true;
            roleCanvas.SetActive(false);
            otherPlayer = null;
            StartCoroutine(StartingGame());
        }

        private System.Random random = new System.Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstu";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private System.Random randomnumbers = new System.Random();
        public string RandomNumberString(int length)
        {
            const string chars = "1234567890";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[randomnumbers.Next(s.Length)]).ToArray());
        }

        public IEnumerator StartingGame()
        {
            while (lookingForOpponent)
            {
                yield return new WaitForSecondsRealtime(1);
                Debug.Log("Coroutine is on");
            }
            while (readyTostart)
            {
                yield return new WaitForSecondsRealtime(2);
                Debug.Log("Ready to start");
                roleCanvas.SetActive(true);
                foreach (Player player in PhotonNetwork.PlayerList)
                {
                   if ((int)player.CustomProperties["isRunner"] == 1)
                    {
                        Debug.Log(player.NickName + " isRunner");
                        RunnerName.text = player.NickName;
                    }
                    else
                    {
                        Debug.Log(player.NickName + " is not Runner");
                        OverlordName.text = player.NickName;
                    }
                }
                PhotonNetwork.LoadLevel("Character");
            }
        }
    }
}