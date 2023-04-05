using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;

public class startButton : MonoBehaviourPunCallbacks
{
    public GameObject startScene; 
    public GameObject AL;
    public GameObject errortext;
    public GameObject waitplayer;
    public TMP_InputField playername;
    public int killby=0;
    public int startGame=0;
    public int clean=0;

    public void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        string filePath1 = Application.dataPath+"/Player1name.json";
        if(gos.Length == 1 && clean==0)
        { 
            if(File.Exists(filePath1))
            {
                photonView.RPC("ReceiveJsonData", RpcTarget.All);
                clean=1;
            }
        }
        if(PhotonNetwork.PlayerList.Length==2)
        {
            waitplayer.active=false;
        }
    }
    [PunRPC]
    private void ReceiveJsonData()
    {
        playername.text = "";
    }

    public void StartGame()
    {
        // print(playername.text);
        if(playername.text!="" && PhotonNetwork.PlayerList.Length==2)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player"); 
            if(gos.Length == 1)
            {
                string filePath1 = Application.dataPath+"/Player1name.json";
                if(File.Exists(filePath1))
                {
                    if(playername.text==LoadFromJson1())
                    {
                        errortext.active=true;
                    }
                    else if(playername.text!=LoadFromJson1())
                    {
                        errortext.active=false;
                        AL.GetComponent<AudioListener>().enabled = false;
                        Invoke("closestart",2);
                        // closestart();
                        startGame=1;
                    }
                }
            }
            else
            {
                errortext.active=false;
                AL.GetComponent<AudioListener>().enabled = false;
                Invoke("closestart",2);
                // closestart();
                startGame=1;
            }
        }   
        else if(PhotonNetwork.PlayerList.Length<2)
        {
            waitplayer.active=true;
        }
    }
    public string LoadFromJson1()
    {
        string json = File.ReadAllText(Application.dataPath + "/Player1name.json");
        jsond data = JsonUtility.FromJson<jsond>(json);
        return data.playername;
    }   
    public void closestart()
    {
        startScene.active=false;
    }

}
