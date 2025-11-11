using System;
using TMPro;
using UnityEngine;

public class HUDTimerController : MonoBehaviour
{

    [SerializeField] private TMP_Text CurrentClock;
    [SerializeField] private TMP_Text Act1Clock;
    [SerializeField] private TMP_Text Act2Clock;
    [SerializeField] private TMP_Text Act3Clock;
    
    private bool _isAct1Running, _isAct2Running, _isAct3Running, _isCurrentRunning;

    private float _act2Start, _act3Start;
    private float _act1Time, _act2Time, _act3Time;
    
    private Animator _currentAnimator, _act1Animator, _act2Animator, _act3Animator;

    private int previousAct = 0;

    private void OnEnable()
    {
        HUDObserverManager.ONActChanged += HandleActChanged;
    }

    private void OnDisable()
    {
        HUDObserverManager.ONActChanged -= HandleActChanged;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _currentAnimator = CurrentClock.GetComponentInChildren<Animator>();
        _act1Animator = Act1Clock.GetComponentInChildren<Animator>();
        _act2Animator = Act2Clock.GetComponentInChildren<Animator>();
        _act3Animator = Act3Clock.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAct1Running) 
        {
            _act1Time += Time.deltaTime;
            Act1Clock.text = ConvertSecondsToMinutesText((int)_act1Time);
        }
        if(_isAct2Running) 
        {
            _act2Time += Time.deltaTime;
            Act2Clock.text = ConvertSecondsToMinutesText((int)_act2Time);
        }
        if(_isAct3Running) 
        {
            _act3Time += Time.deltaTime;
            Act3Clock.text = ConvertSecondsToMinutesText((int)_act3Time);    
        }
        if(_isCurrentRunning)
        {
            int currentTime = (int)_act1Time + (int)_act2Time + (int)_act3Time;
            CurrentClock.text = ConvertSecondsToMinutesText(currentTime);
        }
        
    }

    private void ResetAllTimers()
    {
        _act1Time = 0;
        _act2Time = 0;
        _act3Time = 0;
        Act1Clock.text = ConvertSecondsToMinutesText(0);
        Act2Clock.text = ConvertSecondsToMinutesText(0);
        Act3Clock.text = ConvertSecondsToMinutesText(0);
        CurrentClock.text = ConvertSecondsToMinutesText(0);
        _act1Animator.Play("ClockBeing");
        _act2Animator.Play("ClockBeing");
        _act3Animator.Play("ClockBeing");
        _currentAnimator.Play("ClockBeing");
    }
    
    private void HandleActChanged(int obj)
    {
        switch (previousAct)
        {
            case 1:
                StartAct1Timer(false);
                break;
            case 2:
                StartAct2Timer(false);
                break;
            case 3:
                StartAct3Timer(false);
                StartCurrentTimer(false);
                break;
        }
        
        previousAct = obj;
        switch (obj)
        {
            case 1:
                ResetAllTimers();
                StartAct1Timer(true);
                StartCurrentTimer(true);
                break;
            case 2:
                StartAct2Timer(true);
                break;
            case 3:
                StartAct3Timer(true);
                break;
        }
    }

    public void StartCurrentTimer(bool start)
    {
        _isCurrentRunning = start;
        _currentAnimator.Play(start ? "ClockRunning" : "ClockDone");
    }

    public void StartAct1Timer(bool start)
    {
        _isAct1Running = start;
        _act1Animator.Play(start ? "ClockRunning" : "ClockDone");
    }

    public void StartAct2Timer(bool start)
    {
        _isAct2Running = start;
        _act2Animator.Play(start ? "ClockRunning" : "ClockDone");
    }

    public void StartAct3Timer(bool start)
    {
        _isAct3Running = start;
        _act3Animator.Play(start ? "ClockRunning" : "ClockDone");
    }

   private string ConvertSecondsToMinutesText(int seconds)
    {
        int minutes = seconds / 60;
        int secondsRemainder = seconds - minutes * 60;
        return string.Format("{0:00}:{1:00}", minutes, secondsRemainder);
    }
}
