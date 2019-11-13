using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    public struct TimeRecord
    {
        public string sceneName;
        public int hour;
        public int minute;
        public float second;
    }
    // Start is called before the first frame update
    void Start()
    {
        secondsCount = 0f;
        minuteCount = 0;
        hourCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = hourCount + "h:" + minuteCount.ToString("00") + "m:" + ((int)secondsCount).ToString("00") + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
    private bool isBestPerformance()
    {
        string filepath = "Assets/Record" + SceneManager.GetActiveScene().name + ".tr";
        if (Application.platform == RuntimePlatform.Android)
        {
            filepath = Application.persistentDataPath + "/Record" + SceneManager.GetActiveScene().name + ".tr";
        }
        string json = File.ReadAllText(filepath);
        if(json == null || json.Length == 0)
        {
            return true;
        }
        //Debug.Log("Recored json: " + json);

        TimeRecord historyRecord = JsonUtility.FromJson<TimeRecord>(json);
        if (historyRecord.hour < hourCount)
        {
            return true;
        } else if (historyRecord.hour > hourCount)
        {
            return false;
        } else
        {
            if (historyRecord.minute < minuteCount)
            {
                return true;
            } else if (historyRecord.minute > minuteCount)
            {
                return false;
            } else
            {
                if(historyRecord.second < secondsCount)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

    }
    public void SaveToJsonLocalFile()
    {
        //Debug.Log(isBestPerformance());
        if(!isBestPerformance())
        {
            return;
        }
        TimeRecord tr = new TimeRecord();
        tr.sceneName = SceneManager.GetActiveScene().name;
        tr.hour = hourCount;
        tr.minute = minuteCount;
        tr.second = secondsCount;
        string json = JsonUtility.ToJson(tr);
        //Debug.Log(json);
        string filepath = "Assets/Record" + tr.sceneName + ".tr";
        if(Application.platform == RuntimePlatform.Android)
        {
            filepath = Application.persistentDataPath + "/Record" + tr.sceneName + ".tr";
        }
        //StreamWriter writer = new StreamWriter(filepath, true);
        //writer.Write(json);
        File.WriteAllText(filepath, json);
    }
}
