using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListings;
    [SerializeField]
    private Text _readyUpText;

    private List<PlayerListing> _listing = new List<PlayerListing>();
    private RoomCanvases _roomCanvases;
    private bool _ready = false;

    public override void OnEnable()
    {
        base.OnEnable();
        /*SetReadyUp(false);*/
        GetCurrentRoomPlayers();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i= 0;i < _listing.Count; i++ ){
            Destroy(_listing[i].gameObject);
        }
        _listing.Clear();
    }

    public void FirstInitialize(RoomCanvases canvases) {
        _roomCanvases = canvases;
    }

    /*private void SetReadyUp(bool state) {
        _ready = state;

        if (_ready)
            _readyUpText.text = "R";
        else
            _readyUpText.text = "N";

    }*/

    private void GetCurrentRoomPlayers() {

        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player) {
        int index = _listing.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listing[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(_playerListings, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _listing.Add(listing);
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        //_roomCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listing.FindIndex(x => x.Player == otherPlayer);
            if (index != -1)
            {
                Destroy(_listing[index].gameObject);
                _listing.RemoveAt(index);
            }
    }

    public void StartGame() {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    
    }
}
