using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomProperties : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private Button crear;
    
    

    ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
    public void createName() {
        //Para setear nombre si no hay nada
        System.Random rnd = new System.Random();
        int result = rnd.Next(0,99);

        _text.text = result.ToString();

        _myCustomProperties["CustomName"] =result;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }
    public void customName()
    {
        _myCustomProperties["CustomName"] = _text.text;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
        crear.interactable = true;
    }


}

