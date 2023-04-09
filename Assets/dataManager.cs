using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataManager : MonoBehaviour
{
    public TextAsset textAssetData;
    public string filename = "";

    [System.Serializable]
    public class Record
    {
        public string winnerName;
        public string loserName;
        public string reason;
        public int duration;
        public string date;
    }

    [System.Serializable]
    public class RecordList
    {
        public List<Record> record;
    }

    public RecordList myRecordList = new RecordList();

    private void Update()
    {
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if (gosc.Length > 0)
        {
            Debug.Log("cutScene");
            UpdateRecordPanel();
        }
    }


    public void UpdateRecordPanel()
    {
        GameObject[] record;
        record = GameObject.FindGameObjectsWithTag("record");
        if (myRecordList.record.Count < 4)
        {
            for(int j = 0;j < 2; j++){

            }
            for (int i = 0; i < myRecordList.record.Count; i++)
            {
                GameObject newRecord = Instantiate<GameObject>(Resources.Load("records") as GameObject);
                newRecord.GetComponent<RecordSystem>().DisplayRecord(myRecordList.record[i].winnerName,
                                                                    myRecordList.record[i].loserName,
                                                                    myRecordList.record[i].reason,
                                                                    myRecordList.record[i].date);
                newRecord.transform.parent = gameObject.transform;
            }
        }
    }

    void Start()
    {
        ReadCSV();
        filename = Application.dataPath + "/Resources/TestCSV.csv";
        AddRecord("Hi", "Bye", "grenade", "1/1/1");

    }

    public void ReadCSV()
    {
        textAssetData = Resources.Load<TextAsset>("TestCSV");
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        int tableSize = data.Length / 4 - 1;
        for (int i = 0; i < tableSize; i++)
        {
            myRecordList.record.Add(new Record());
            myRecordList.record[i].winnerName = data[5 * (i + 1)];
            myRecordList.record[i].loserName = data[5 * (i + 1) + 1];
            myRecordList.record[i].reason = data[5 * (i + 1) + 2];
            // myRecordList.record[i].duration = int.Parse(data[5*(i+1) +3]);
            myRecordList.record[i].date = data[5 * (i + 1) + 4];
        }

    }

    public void AddRecord(string winnerName, string loserName, string reasonOfDeath, string date)
    {
        Record newRecord = new Record();
        newRecord.winnerName = winnerName;
        newRecord.loserName = loserName;
        newRecord.reason = reasonOfDeath;
        newRecord.date = date;
        myRecordList.record.Add(newRecord);
        WriteCSV(newRecord);
    }

    public void WriteCSV(Record newRecord)
    {
        TextWriter textWriter = new StreamWriter(filename, true);
        textWriter.WriteLine(newRecord.winnerName + "," + newRecord.loserName + "," + newRecord.reason + "," + newRecord.date);
        textWriter.Close();
    }
}