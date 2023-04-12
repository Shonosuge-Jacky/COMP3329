using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waiting : MonoBehaviour
{
    public Text textcp;
    public GameObject loadgif;
    public GameObject loadgif2;
    public GameObject loadgif3;
    public int stage=0;

    void Start()
    {
        // Invoke("closestart",2);
    } 
    public void closestart()
    {
        textcp.enabled=true;
        loadgif.active=true;
        loadgif2.active=true;
        loadgif3.active=true;
    }

    void Update()
    {
        if(stage==0)
        {
            Invoke("closestart",2);
            stage=1;
        }

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player"); 
        // print(gos.Length);
        if(gos.Length == 2)
        {
            textcp.enabled=false;
            loadgif.active=false;
            loadgif2.active=false;
            loadgif3.active=false;
        }
    }

}
