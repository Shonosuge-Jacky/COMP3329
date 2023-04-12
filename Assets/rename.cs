using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;

public class rename : MonoBehaviour
{
    public int LRed=0;
    public Canvas UI;
    public Image UImage;
    public GameObject UIplace;
    public GameObject startScene;
    public int stagec=0;
    void Update()
    {       
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            LRed=0;
			stagec=1;
		}
        if(gosc.Length == 0 && stagec==1)
        {  
			stagec=0;
		}

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("endGame"); 
        if(gos.Length == 0)
        {
        }
        else
        {
            if(LRed==0)
            {
                Invoke("closestart",3);
                LRed=1;
            }
        }  

        if (Input.GetKey("a") && LRed==2)
        {
            // UImage.enabled=true;
            // UIplace.active=true;
            // startScene.active=true;
            // LRed=3;
            // Cursor.lockState = CursorLockMode.None;
            // Cursor.visible = true;
        }      
    }
    public void closestart()
    {
        LRed=2;
    }   


}
