using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListings;

    private List<RoomListing> _listing = new List<RoomListing>();
    private RoomCanvases _roomCanvases;

    public void FirstInitialize(RoomCanvases canvases) {
        _roomCanvases = canvases;
    }

    public override void OnJoinedRoom() {
        _roomCanvases.CurrentRoomCanvas.Show();
        _content.DestroyChildren();
        _listing.Clear();
    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList) {
            //Se removio de la lista
            if (info.RemovedFromList)
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index !=-1) {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            //Se agrego sala a la lista
            else
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = (RoomListing)Instantiate(_roomListings, _content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listing.Add(listing);
                    }
                }
                else { 
                    //Modificar listado aqui
                    //_listings[index].doSomething
                
                }
            }
        }
    }
}
