using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIRecord : MonoBehaviour
{
    public Text winnerName;
    public Text loserName;
    public Text gameDuration;
    public Text date;
    public Text record;
    // Start is called before the first frame update
    void Start()
    {
        // winnerName = GetComponent<Transform>().Find("WinnerName").GetComponent<Text>();
        // loserName = GetComponent<Transform>().Find("LoserName").GetComponent<Text>();
        // gameDuration = GetComponent<Transform>().Find("GameDuration").GetComponent<Text>();
        // date = GetComponent<Transform>().Find("Date").GetComponent<Text>();
        // record = GetComponent<Transform>().Find("Text").GetComponent<Text>();
        // dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    public void GetInfo(string RwinnerName, string RloserName, string Rreason, string Rduration, string Rdate){
        Debug.Log(RwinnerName +" to " + winnerName);
        winnerName.text = RwinnerName;
        loserName.text = RloserName;
        gameDuration.text = Rduration;
        date.text = Rdate;
        record.text = Rreason;
    }
    


}