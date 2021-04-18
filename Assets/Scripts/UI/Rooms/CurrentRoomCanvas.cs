using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    private RoomCanvases _roomsCanvases;
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
        _playerListingsMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void OnClick_LeaveRoom() { 
        
    }

}
