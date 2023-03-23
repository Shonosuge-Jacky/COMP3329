using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class startButton : MonoBehaviour
{
    public GameObject startScene; 
    public GameObject AL;
    public TMP_InputField playername;
    public int killby=0;
    public int startGame=0;

    public void StartGame()
    {
        // print(playername.text);
        if(playername.text!="")
        {
            AL.GetComponent<AudioListener>().enabled = false;
            Invoke("closestart",2);
            startGame=1;
        }   
    }
    public void closestart()
    {
        startScene.active=false;
    }

}
