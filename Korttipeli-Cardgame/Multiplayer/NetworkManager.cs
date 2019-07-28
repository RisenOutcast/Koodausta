using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RO
{
    public class NetworkManager : Photon.PunBehaviour
    {
        public bool isMaster;
        public static NetworkManager singleton;

        List<MultiplayerHolder> multiplayerHolders = new List<MultiplayerHolder>();
        public MultiplayerHolder GetHolder(int photonId)
        {
            for (int i = 0; i < multiplayerHolders.Count; i++)
            {
                if (multiplayerHolders[i].ownerId == photonId)
                {
                    return multiplayerHolders[i];
                }
            }

            return null;
        }

        public Kortti GetCard(int instId, int ownerId)
        {
            MultiplayerHolder h = GetHolder(ownerId);
            return h.GetCard(instId);
        }

        ResurssiSäätäjä rs;
        int cardinstIds;

        public StringVariable logger;
        public PeliEventit loggerUpdated;
        public PeliEventit failedToConnect;
        public PeliEventit onConnected;
        public PeliEventit waitingForPlayer;

        private void Awake()
        {
            if (singleton == null)
            {
                rs = Resources.Load("ResurssiSäätäjä") as ResurssiSäätäjä;
                singleton = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            PhotonNetwork.autoCleanUpPlayerObjects = false;
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.automaticallySyncScene = false;
            Init();
        }

        public void Init()
        {
            PhotonNetwork.ConnectUsingSettings("1");
            logger.value = "Connecting";
            loggerUpdated.Raise();
        }

        #region My Calls
        public void OnPlayGame()
        {
            JoinRandomRoom();
        }

        void JoinRandomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        void CreateRoom()
        {
            RoomOptions room = new RoomOptions();
            room.MaxPlayers = 2;
            PhotonNetwork.CreateRoom(RandomString(256), room, TypedLobby.Default);
        }

        private System.Random random = new System.Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstu";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Master Only
        public void PlayerJoined(int photonId, string[] kortit)
        {
            MultiplayerHolder m = new MultiplayerHolder();
            m.ownerId = photonId;

            for (int i = 0; i < kortit.Length-1; i++)
            {
                Kortti k = CreateCardMaster(kortit[i]);
                if (k == null)
                    continue;

                m.RegisterCard(k);
                //RPC
            }
        }

        Kortti CreateCardMaster(string cardId)
        {
            Kortti kortti = rs.HaeKorttiInstanssi(cardId);
            kortti.instId = cardinstIds;
            cardinstIds++;

            return kortti;
        }

        void CreateCardClient_call(string cardId, int instId, int photonId)
        {
            Kortti k = CreateCardClient(cardId, instId);
            if (k != null)
            {
                MultiplayerHolder h = GetHolder(photonId);
                h.RegisterCard(k);
            }
        }

        Kortti CreateCardClient(string cardId, int instId)
        {
            Kortti kortti = rs.HaeKorttiInstanssi(cardId);
            kortti.instId = instId;

            return kortti;
        }
        #endregion

        #region Photon Callbacks

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            logger.value = "Connected!";
            loggerUpdated.Raise();
            onConnected.Raise();
        }

        public override void OnFailedToConnectToPhoton(DisconnectCause cause)
        {
            base.OnFailedToConnectToPhoton(cause);
            logger.value = "Failed to connect.";
            loggerUpdated.Raise();
            onConnected.Raise();
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            base.OnPhotonRandomJoinFailed(codeAndMsg);
            CreateRoom();
        }

        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();
            isMaster = true;
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            logger.value = "Waiting for challenger.";
            loggerUpdated.Raise();
            waitingForPlayer.Raise();
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
        {
            if (isMaster)
            {
                if(PhotonNetwork.playerList.Length > 1)
                {
                    logger.value = "Match starting!";
                    loggerUpdated.Raise();

                    PhotonNetwork.room.IsOpen = false;
                    PhotonNetwork.Instantiate("MultiplayerManager", Vector3.zero, Quaternion.identity, 0);
                    //Start match
                }
            }
        }

        public void LoadGameScene()
        {
            SessionManager.singleton.LoadGameLevel(OnGameSceneLoaded);
        }

        void OnGameSceneLoaded()
        {
            MultiplayerManager.singleton.countPlayers = true;
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
        }
        #endregion

        #region RPCs
        #endregion
    }

    public class MultiplayerHolder
    {
        public int ownerId;
        Dictionary<int, Kortti> kortit = new Dictionary<int, Kortti>();

        public void RegisterCard(Kortti k)
        {
            kortit.Add(k.instId, k);
        }

        public Kortti GetCard(int instId)
        {
            Kortti r = null;
            kortit.TryGetValue(instId, out r);
            return r;
        }
    }
}