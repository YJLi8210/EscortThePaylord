using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
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
}
