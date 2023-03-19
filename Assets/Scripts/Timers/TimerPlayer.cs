using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPlayer : MonoBehaviour
{
    [SerializeField] private float _time = 15;
    private float _timer;
    private bool _canT;

    private void  FixedUpdate()
    {
        _timer = _timer - Time.deltaTime;
    }

    public int Timer()
    {
        if (_canT && _timer <= 0)
        {
            _canT = false;
            return 1;
        }
        if (!_canT)
        {
            _timer = _time;
            _canT = true;
            return 0;
        }
        return 0;
    }

    public void TimerRemove()
    {
        _canT = false;
        _timer = 0;
    }
}
