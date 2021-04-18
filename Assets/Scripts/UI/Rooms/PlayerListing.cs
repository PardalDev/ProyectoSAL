using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player) {
        Player = player;

        if (player.CustomProperties.ContainsKey("CustomName"))
        {
            string result = (string)player.CustomProperties["CustomName"];
            //_text.text = player.NickName;
            _text.text = result;
        }
        else {
            System.Random rnd = new System.Random();
            int resultado = rnd.Next(0, 5000); 
            _text.text = "Default_" + resultado;
        }
        //_text.text = result.ToString() +"," +  player.NickName;
        
    }
    
}
