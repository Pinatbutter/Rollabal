using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System.Diagnostics;


public class TimerCode : MonoBehaviour
{

    private float startTime;

    public bool timeFinished;
    public int TotalSeconds = 0;
    public TextMeshProUGUI timer;
    public GameObject playerObject;

    public void youWon(bool won)
    {
        timeFinished = won;
    }
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timeFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFinished == false)
        {
            float t = Time.time - startTime;
            string seconds = ((int)(TotalSeconds - (t % 60))).ToString();

            timer.text = seconds;
            if (seconds == "0")
            {
                timeFinished = true;
                playerObject.SendMessage("youLost", timeFinished);
            }
        }
    }

}
