using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    private int stopconnect=0;
    private int player=0;
    private int joined=0;
    private int stage=0;
    private int f1=0;
    private int f2=0;
    public startButton startButton;
    public GameObject Crosshir;

    // Start is called before the first frame update
    void Start()
    {
        string filePath1 = Application.dataPath+"/Player1name.json";
        string filePath2 = Application.dataPath+"/Player2name.json";
        if (File.Exists(filePath1))
        {
            // Delete the file
            File.Delete(filePath1);
            Debug.Log("File1 deleted successfully");
        }
        else
        {
            Debug.LogError("File1 does not exist");
        }
        if (File.Exists(filePath2))
        {
            // Delete the file
            File.Delete(filePath2);
            Debug.Log("File2 deleted successfully");
        }
        else
        {
            Debug.LogError("File2 does not exist");
        }
        //try to connect
        // PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectUsingSettings(); 
        player=0;       
    }

    private void Update()
    {      
        string filePath1 = Application.dataPath+"/Player1name.json";
        string filePath2 = Application.dataPath+"/Player2name.json";
        GameObject[] gos1;
        gos1 = GameObject.FindGameObjectsWithTag("Player");
        if (File.Exists(filePath1))
        {
            f1=1;
        }
        else
        {
            f1=2;
        }
        if(joined==1 && player==0 && startButton.startGame==1 && gos1.Length == 0)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(14,2,31), Quaternion.identity);
            player=1;
            Crosshir.active = true; 
        }  
        if(joined==1 && player==0 && startButton.startGame==1 && gos1.Length == 1 && f1==1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(14,2,31), Quaternion.identity);
            player=1;
            Crosshir.active = true; 
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
        joined=1; 
    }

//===================================================================================
    
    // // Start is called before the first frame update
    // void Start()
    // {
    //     //try to connect
    //     // PhotonNetwork.ConnectUsingSettings();        
    // }

    // private void Update()
    // {
    //     if(stopconnect==0 && startButton.startGame==1)
    //     {
    //         PhotonNetwork.ConnectUsingSettings(); 
    //         stopconnect=1;
    //     }        
    // }

    // public override void OnConnectedToMaster()
    // {
    //     //we connected
    //     Debug.Log("Connected to Master");
    //     PhotonNetwork.JoinRandomOrCreateRoom();
    // }

    // public override void OnJoinedRoom()
    // {
    //     Debug.Log("Joined a room successfully!");
    //     Crosshir.active = true;
    //     PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(14,2,31), Quaternion.identity);
    // }
}
