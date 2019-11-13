using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class RecordManager : MonoBehaviour
{
    public TextMeshProUGUI Level1Text;
    public TextMeshProUGUI Level2Text;
    private void Start()
    {
        LoadBestHistory();
    }
    void LoadBestHistory()
    {
        Timer.TimeRecord historyRecord;
        string level1Filepath = "Assets/Recordmap.tr";
        if (Application.platform == RuntimePlatform.Android)
        {
            level1Filepath = Application.persistentDataPath + "/Recordmap.tr";
        }
        
        string lvl1jJson = File.ReadAllText(level1Filepath);
        if(lvl1jJson != null && lvl1jJson.Length > 2)
        {
            historyRecord = JsonUtility.FromJson<Timer.TimeRecord>(lvl1jJson);
            string timeText = historyRecord.hour + "h:" + historyRecord.minute.ToString("00") + "m:" + ((int)historyRecord.second).ToString("00") + "s";
            Level1Text.text += "(" + timeText + ")";
        } else
        {
            Level1Text.text += "(No Record)";
        }


        string level2Filepath = "Assets/RecordMap2.tr";
        if (Application.platform == RuntimePlatform.Android)
        {
            level1Filepath = Application.persistentDataPath + "/RecordMap2.tr";
        }
        string lvl2jJson = File.ReadAllText(level2Filepath);
        if (lvl2jJson != null && lvl2jJson.Length > 2)
        {
            historyRecord = JsonUtility.FromJson<Timer.TimeRecord>(lvl2jJson);
            string timeText = historyRecord.hour + "h:" + historyRecord.minute.ToString("00") + "m:" + ((int)historyRecord.second).ToString("00") + "s";
            Level2Text.text += "(" + timeText + ")";
        }
        else
        {
            Level2Text.text += "(No Record)";
        }
    }
}
