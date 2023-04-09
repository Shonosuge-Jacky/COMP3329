using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecordSystem : MonoBehaviour
{
    public DataManager dm;
    public Text winnerName;
    public Text loserName;
    public Text deathReason;
    public Text date;

    private void Awake() {
        dm = GameObject.Find("DataManager").GetComponent<DataManager>();
    }
    public void DisplayRecord(){
        for(int i = 0 ;i < dm.myRecordList.record.Count; i++){
            winnerName.text = dm.myRecordList.record[i].winnerName;
            loserName.text = dm.myRecordList.record[i].loserName;
            deathReason.text = dm.myRecordList.record[i].reason;
            date.text = dm.myRecordList.record[i].date;
        }
        
    }
}
