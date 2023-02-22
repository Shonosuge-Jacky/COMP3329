using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public GameObject startScene; 
    public GameObject AL;
    public int startGame=0;
    // Start is called before the first frame update
    public void StartGame()
    {
        AL.GetComponent<AudioListener>().enabled = false;
        Invoke("closestart",2);
        startGame=1;
    }
    public void closestart()
    {
        startScene.active=false;
    }

}
