using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.XR;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;
    

    private RoomCanvases _roomsCanvases;

    //TestName
    ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
    }




    public void OnClick_CreateRoom() {

        if (!PhotonNetwork.IsConnected)
            return;
        //Create room
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 40;

        _myCustomProperties["CustomName"] = _roomName.text;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;

        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
        //Join Room

    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created Successfully", this);
        _roomsCanvases.CurrentRoomCanvas.Show();


    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed " + message, this);
    }
}
