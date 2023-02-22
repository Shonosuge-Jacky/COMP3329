using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    private int stopconnect=0;
    public startButton startButton;

    // Start is called before the first frame update
    void Start()
    {
        //try to connect
        // PhotonNetwork.ConnectUsingSettings();        
    }

    private void Update()
    {
        if(stopconnect==0 && startButton.startGame==1)
        {
            PhotonNetwork.ConnectUsingSettings(); 
            stopconnect=1;
        }
        
    }

    public override void OnConnectedToMaster()
    {
        //we connected
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room successfully!");
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(14,2,31), Quaternion.identity);
    }
}
