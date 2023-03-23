using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;


public class deadReason : MonoBehaviourPunCallbacks
{
    public Text ScoreText;
    private int done=0;
    private int done2=0;
    private int done3=0;
    private int done4=0;
    private int f1=0;
    private int f2=0;
    private string dieby;
    private string player1;
    private string player2;
    private string myname;
    private string hisname;
    public GameObject user;
    
    // Update is called once per frame
        
    public string LoadFromJson1()
    {
        string json = File.ReadAllText(Application.dataPath + "/Player1name.json");
        jsond data = JsonUtility.FromJson<jsond>(json);
        return data.playername;
    }   
    public string LoadFromJson2()
    {
        string json = File.ReadAllText(Application.dataPath + "/Player2name.json");
        jsond data = JsonUtility.FromJson<jsond>(json);
        return data.playername;
    }

    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player"); 
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("DieReason"); 
        GameObject[] gos3;
        gos3 = GameObject.FindGameObjectsWithTag("endGame");
        string filePath1 = Application.dataPath+"/Player1name.json";
        string filePath2 = Application.dataPath+"/Player2name.json";
        if (File.Exists(filePath1))
        {
            f1=1;
        }
        else
        {
            f1=2;
        }
        if (File.Exists(filePath1))
        {
            f2=1;
        }
        else
        {
            f2=2;
        }
        if(gos.Length == 2 && done4==0)
        {
            if(user.name=="player1" && f1==1 && f2==1)
            {
                myname=LoadFromJson1();
                hisname=LoadFromJson2();
                done4=1;
            }
            else if(user.name=="player2" && f1==1 && f2==1)
            {
                myname=LoadFromJson2();
                hisname=LoadFromJson1();
                done4=1;
            }
        }  
        if(photonView.IsMine && gos3.Length == 1 && done==0)
        {
            ScoreText.enabled=true;
            if((gos2[0].name).ToString()=="RIN(Clone)")
            {
                dieby = "'s Craker Grenade";
            }
            else if((gos2[0].name).ToString()=="YIN(Clone)")
            {
                dieby = "'s Remote Grenade";
            }
            else if((gos2[0].name).ToString()=="GIN(Clone)")
            {
                dieby = "'s Gas Grenade";
            }
            else if((gos2[0].name).ToString()=="OIN(Clone)")
            {
                dieby = "was drowned";
            }
            done=1;
        } 
        if(photonView.IsMine && done==1 && done2==0)
        {
            if((gos3[0].name).ToString()=="player11" || (gos3[0].name).ToString()=="player21")
            {
                ScoreText.text = myname+" is killed by "+hisname+dieby;
                done2=1;
                print("3.1");
            }
            if((gos3[0].name).ToString()=="player12" || (gos3[0].name).ToString()=="player22")
            {
                ScoreText.text = myname+" is killed by it's own "+dieby;
                done2=1;
                print("3.2");
            }
            if((gos3[0].name).ToString()=="User(Clone)1")
            {
                ScoreText.text = hisname+" is killed by "+myname+dieby;
                done2=1;
                print("3.3");
            }
            if((gos3[0].name).ToString()=="User(Clone)2")
            {
                ScoreText.text = hisname+" is killed by it's own "+dieby;
                done2=1;
                print("3.4");
            }           
        }  

        // GameObject[] gos;
        // gos = GameObject.FindGameObjectsWithTag("PlayerName"); 
        // print("test");
        // print(gos.Length);
        // if(photonView.IsMine && gos.Length == 2 && done3==0)
    }
}
