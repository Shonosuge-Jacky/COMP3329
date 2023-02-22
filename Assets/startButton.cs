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
    public int startGame=0;
    // Start is called before the first frame update
    public void StartGame()
    {
        if(playername.text!="")
        {
            AL.GetComponent<AudioListener>().enabled = false;
            Invoke("closestart",2);
            startGame=1;
        }
        print(playername.text);
    }
    public void closestart()
    {
        startScene.active=false;
    }

}
