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
        string lvl1jJson = File.ReadAllText(level1Filepath);
        historyRecord = JsonUtility.FromJson<Timer.TimeRecord>(lvl1jJson);
        string timeText = historyRecord.hour + "h:" + historyRecord.minute.ToString("00") + "m:" + ((int)historyRecord.second).ToString("00") + "s";
        Level1Text.text += "(" + timeText + ")";

        string level2Filepath = "Assets/RecordMap2.tr";
        string lvl2jJson = File.ReadAllText(level2Filepath);
        historyRecord = JsonUtility.FromJson<Timer.TimeRecord>(lvl2jJson);
        timeText = historyRecord.hour + "h:" + historyRecord.minute.ToString("00") + "m:" + ((int)historyRecord.second).ToString("00") + "s";
        Level2Text.text += "(" + timeText + ")";
    }
}
