using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public InputField createInput;
    public InputField joinInput;

    
    //Methods to create / join lobbies based on the inputfield text

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    //Load Game upon Joining Lobby
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Scene_A");
    }
}
