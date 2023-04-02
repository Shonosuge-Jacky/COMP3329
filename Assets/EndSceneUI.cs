using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneUI : MonoBehaviour
{
    public Text result;
    public string playername;
    public GameObject recordContent;
    public DataManager dataManager;

    void OnEnable() {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        Debug.Log("EndScene, record no. = " + dataManager.myRecordList.record.Count); 
        // GameObject newRecord = (GameObject)Instantiate(Resources.Load("UI/Record"), recordContent.transform);
        // EndUIRecord newEndRecord = newRecord.GetComponent<EndUIRecord>();
        
        // newEndRecord.GetInfo(dataManager.myRecordList.record[dataManager.myRecordList.record.Count-1].winnerName,
        //                     dataManager.myRecordList.record[dataManager.myRecordList.record.Count-1].winnerName,
        //                     dataManager.myRecordList.record[dataManager.myRecordList.record.Count-1].winnerName,
        //                     dataManager.myRecordList.record[dataManager.myRecordList.record.Count-1].winnerName,
        //                     dataManager.myRecordList.record[dataManager.myRecordList.record.Count-1].winnerName
        //                     );
        

        for(int i = dataManager.myRecordList.record.Count - 1 ; i >=0 ; i--){
            Debug.Log(i);
            GameObject newRecord = (GameObject)Instantiate(Resources.Load("UI/Record"), recordContent.transform);
            EndUIRecord newEndRecord = newRecord.GetComponent<EndUIRecord>();
            newEndRecord.GetInfo(dataManager.myRecordList.record[i].winnerName,
                                    dataManager.myRecordList.record[i].loserName,
                                    dataManager.myRecordList.record[i].reason,
                                    dataManager.myRecordList.record[i].duration.ToString(),
                                    dataManager.myRecordList.record[i].date
                                    );
        }
    }


}
