using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPlayer : MonoBehaviour
{
    [SerializeField] private float _time = 20;
    private float _timer;
    public float timer => _time;
    private bool _canT;
    //[SerializeField] private GameObject _timerButton;
    private int _timerInt;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void  FixedUpdate()
    {
        if (_canT && _timer > 0)
        {
            _timer = _timer - Time.deltaTime;
            _timerInt = (int)_timer;
            //var strText = _timerButton.GetComponentInChildren<TextMeshProUGUI>();
            _timerText.text = _timerInt.ToString();
            if (_timer < 6 && _timerText.color == Color.white)
            {
                _timerText.color = Color.red; 
            }
            return;
        }
        _timerText.color = Color.white;
        _timerText.text = ("-");
    }

    // public int Timer()
    // {
    //     if (_canT && _timer <= 0)
    //     {
    //         _canT = false;
    //         return 1;
    //     }
    //     if (!_canT)
    //     {
    //         _timer = _time;
    //         _canT = true;
    //         return 0;
    //     }
    //     return 0;
    // }

    public void TimerGo()
    {
        _timer = _time;
        _canT = true;
    }
    
    public void TimerRemove()
    {
        _canT = false;
        _timer = 0;
    }
}
