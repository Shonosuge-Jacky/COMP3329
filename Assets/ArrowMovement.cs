using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArrowMovement : MonoBehaviourPunCallbacks
{
    public GameObject L;
    public GameObject R;
    public GameObject RW;
    public GameObject recordList;
    public int count=0;
    public int stage=0;
    public int stagec=0;
    public int canend=0;
    public int ded=0;
    public int LRed=0;
    public int mp4=0;
    public GameObject WINNER;
    public GameObject LOSER;
    public GameObject cutscene;
    public DataManager dm;


    private void Awake() {
        dm = GameObject.Find("DataManager").GetComponent<DataManager>();
    }
    void Update()
    {		       
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            count=0;
            stage=0;
            canend=0;
            ded=0;
            LRed=0;
            mp4=0;
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

        if (Input.GetKey("d") && LRed==2)
        {
            if(photonView.IsMine)
            {
                photonView.RPC("changeD",RpcTarget.All);
            }
            recordList.SetActive(false);
            RW.active=true;
            R.active=false;
            LRed=3;
        }

    }
    public void DisplayRecordList(){
        recordList.SetActive(true);
        GameObject content = recordList.transform.Find("Viewport").gameObject;
        // foreach (Transform child in transform){
        //     Destroy(child.gameObject);
        // }
        for(int i = dm.myRecordList.record.Count-1; i >=0 ; i--){
            GameObject newRecord = Instantiate<GameObject>(Resources.Load("record") as GameObject);
            newRecord.GetComponent<RecordSystem>().DisplayRecord(dm.myRecordList.record[i].winnerName,
                                                                dm.myRecordList.record[i].loserName,
                                                                dm.myRecordList.record[i].reason,
                                                                dm.myRecordList.record[i].date);
            newRecord.transform.parent = content.transform;
        }
    }

    [PunRPC]
    void changeD()
    {
        Rigidbody rb = Instantiate(cutscene, transform.position, transform.rotation).GetComponent<Rigidbody>(); 
    }  

    public void closestart()
    {
        DisplayRecordList();
        L.active=true;
        R.active=true;
        LRed=2;
    }   
    public void win()
    {
        WINNER.active=true;
    }  
    public void lose()
    {
        LOSER.active=true;
    } 


}

// if(count==0)
// {
//     stage=0;
// }
// else if(count==35)
// {
//     stage=1;
// }

// if(stage==0)
// {
//     L.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0.1f, 0f);
//     count=count+1;
// }
// else if(stage==1)
// {
//     L.GetComponent<RectTransform>().anchoredPosition += new Vector2(0.1f, 0f);
//     count=count-1;
// }