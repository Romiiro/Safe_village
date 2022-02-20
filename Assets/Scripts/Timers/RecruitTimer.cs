using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitTimer : Timer {
    [SerializeField] private RecruitButton _parrentButton;

    private bool _timerIsOn;

    public bool TimerIsOn => _timerIsOn;

   
    public override void RoundIsDone() {
        StopTimer();
        _parrentButton.ActivateButton();
    }

    private void FixedUpdate() {
        if(_timerIsOn) {
            _timer += Time.deltaTime * _timeSpeedPaused;
            if (_timer >= _timerRound) {
                RoundIsDone();
                _timer = 0;
            }
        }
    }

    public void StopTimer() {
        _timerIsOn = false;
    }

    public void StartTimer() {
        _timerIsOn = true;
    }

    public override void Reset() {
        StopTimer();
        _parrentButton.ActivateButton();
        base.Reset();
    }
}
