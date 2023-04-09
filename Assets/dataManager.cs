using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public TextAsset textAssetData;
    public string filename = "";
    public ArrowMovement arm;

    [System.Serializable]
    public class Record
    {
        public string winnerName;
        public string loserName;
        public string reason;
        // public int duration;
        public string date;
    }

    [System.Serializable]
    public class RecordList
    {
        public List<Record> record;
    }

    public RecordList myRecordList = new RecordList();


    void Start()
    {
        ReadCSV();
        filename = Application.dataPath + "/Resources/TestCSV.csv";
    }

    public void ReadCSV()
    {
        textAssetData = Resources.Load<TextAsset>("TestCSV");
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        int tableSize = data.Length / 4 - 1;
        for (int i = 0; i < tableSize; i++)
        {
            myRecordList.record.Add(new Record());
            myRecordList.record[i].winnerName = data[4 * (i + 1)];
            myRecordList.record[i].loserName = data[4 * (i + 1) + 1];
            myRecordList.record[i].reason = data[4 * (i + 1) + 2];
            // myRecordList.record[i].duration = int.Parse(data[5*(i+1) +3]);
            myRecordList.record[i].date = data[4 * (i + 1) + 3];
        }

    }

    public void AddRecord(string winnerName, string loserName, string reasonOfDeath, string date)
    {
        Debug.Log("ADDRESULT");
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