using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{

    private void Start()
    {
        print("Connecting to server.. " );
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion =MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();


    }


    public override void OnConnectedToMaster() {

        print("Connected to server!!");
        print(PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }

    }

    public override void OnDisconnected(DisconnectCause a)
    {

        print("Disconnected to server: " + a.ToString());

    }
}
