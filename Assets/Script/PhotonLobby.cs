using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks {

    public static PhotonLobby lobby;

    public GameObject battleButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this;
    }

    // Use this for initialization
    void Start () {

        PhotonNetwork.ConnectUsingSettings();
        
    }
	
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        battleButton.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnBattleClicked()
    {
        Debug.Log("Finding...");
        PhotonNetwork.JoinRandomRoom();
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
    }

    public void OnCancelClicke()
    {
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No random room avaliable. There must be open games");
        CreateRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Trid to create room but faield, There must be room with that name");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Creating room...");
        int randomRoom = 50;
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerScript.multiplayerSetting.maxPlayers };
        PhotonNetwork.CreateRoom("Room" + randomRoom, roomOps);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
