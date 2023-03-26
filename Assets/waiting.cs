using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waiting : MonoBehaviour
{
    public Text textcp;
    public GameObject loadgif;

    void Start()
    {
        Invoke("closestart",2);
    } 
    public void closestart()
    {
        textcp.enabled=true;
        loadgif.active=true;
    }

    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player"); 
        if(gos.Length == 2)
        {
            textcp.enabled=false;
            loadgif.active=false;
        }
    }

}
