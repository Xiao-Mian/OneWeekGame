using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public Text _timeCounter;
    public Text _finalTime;
    public Text _fastestTime;


    private TimeSpan _timePlaying;
    TimeSpan _finalFastestTime;
    private bool _timerGoing;

    private float _elapsedTime;



    public void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        _timeCounter.text = "00:00.00";
        _timerGoing = false;
        
        _fastestTime.text = PlayerPrefs.GetString("FastestTime", _fastestTime.text);
        //Reset();
        BeginTimer();
    }

    public void Reset()
    {
        
        _fastestTime.text = null;
    }


    public void BeginTimer()
    {
        _timerGoing = true;
        _elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    
    public void EndTimer()
    {
        
        _timerGoing = false;
        _finalTime.text = _timeCounter.text;
    }

    IEnumerator UpdateTimer()
    {
        while (_timerGoing)
        {
            _elapsedTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(_elapsedTime);
            string timePlayingStr = _timePlaying.ToString("mm' : 'ss' . 'ff");
            _timeCounter.text = timePlayingStr;

            yield return null;
        }


    }

    public void UpdateTime()
    {
            _finalFastestTime = _timePlaying;
            string fastestTime = _finalFastestTime.ToString("mm' : 'ss' . 'ff");
            _fastestTime.text = fastestTime;
            

            PlayerPrefs.SetString("FastestTime", _fastestTime.text);
            PlayerPrefs.Save();

    }

    void Update()
    {
        
        
    }



}
