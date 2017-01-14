using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class UpdateCountDown : MonoBehaviour {
    public Text countDownText;
    public GameObject finishText;
    public bool stop = true;
    public float timeLeft = 0.0f;
    private float lastTime = 0.0f;

    public event Action OnTimerStarted;
    public event Action OnTimerTicked;
    public event Action OnTimerFinished; 

    // Use this for initialization
    void Start () {

    }

    public void startTimer(float from)
    {
        timeLeft = from;
        lastTime = timeLeft;
        stop = false;
        if (OnTimerStarted != null)
        {
            OnTimerStarted();
        }
    }

    void Update()
    {
        if (stop) return;
        if (timeLeft < 0)//时间到，返回主场景重新开始
        {
            stop = true;
            ShowEndUI();
            return;
        }
        timeLeft -= Time.deltaTime;
        if (lastTime - timeLeft > 1.0f)
        {
            UpdateUI();
            lastTime = timeLeft;
        }
    }

    private void UpdateUI()
    {
        //Debug.Log(timeLeft.ToString("F0"));
        countDownText.text = timeLeft.ToString("F0");
        if (timeLeft < 30.0f)
        {
            countDownText.color = Color.red;
        }
        PlayerPrefs.SetFloat("CountDownTime", timeLeft);    
    }

    private void ShowEndUI()
    {
        finishText.SetActive(true);
    }
    
}
