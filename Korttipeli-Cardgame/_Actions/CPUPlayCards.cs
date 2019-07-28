using UnityEngine;
using System.Collections;

namespace RO.GameStates
{
    [CreateAssetMenu(menuName = "States/Actions/CPUPlayCards")]
    public class CPUPlayCards : Action
    {
        public override void Execute(float d)
        {
            //Settings.peliSäätäjä.currentPlayer.kortitKädes
            //Haje kortit kädestä ja nakkaa ramdomilla kaikki mitä pystyy pöydälle.
        }
    }
}