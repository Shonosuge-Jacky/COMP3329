using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Photon.Pun;

public class jsonrw : MonoBehaviourPunCallbacks 
{
    public TMP_InputField idInputField;
    private int done=0;
    private int done1=0;
    private int done2=0;
    private int done3=0;
    private int verydone=0;
    private PhotonView photonView;
    public int player=0;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        GameObject[] gos1;
        gos1 = GameObject.FindGameObjectsWithTag("Player");
        if(done==0)
        {
            if(gos1.Length == 1)
            {
                jsond data = new jsond();
                data.playername =  idInputField.text;
                string json = JsonUtility.ToJson(data, true);
                File.WriteAllText(Application.dataPath+"/Player1name.json", json);
                photonView.RPC("ReceiveJsonData", RpcTarget.Others, json);
                done=1;
            } 
        }
        if(done2==0)
        {
            if(gos1.Length == 2)
            {
                jsond data2 = new jsond();
                data2.playername =  idInputField.text;
                string json2 = JsonUtility.ToJson(data2, true);
                File.WriteAllText(Application.dataPath+"/Player2name.json", json2);
                photonView.RPC("ReceiveJsonData", RpcTarget.Others, json2);
                done2=1;
            } 
        } 
    }    

    [PunRPC]
    private void ReceiveJsonData(string jsonData)
    {
        jsond data = JsonUtility.FromJson<jsond>(jsonData);
        idInputField.text = data.playername;
    }
}
