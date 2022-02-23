#region

using UnityEngine;

#endregion

public class RecruitTimer : Timer {
    private bool _timerIsOn;
    [SerializeField] private RecruitButton _parrentButton;

    public bool TimerIsOn => _timerIsOn;

    public override void Reset() {
        StopTimer();
        _parrentButton.ActivateButton();
        base.Reset();
    }


    public override void RoundIsDone() {
        StopTimer();
        _parrentButton.ActivateButton();
    }

    public void StartTimer() {
        _timerIsOn = true;
    }

    public void StopTimer() {
        _timerIsOn = false;
    }

    private void FixedUpdate() {
        if (_timerIsOn) {
            _timer += Time.deltaTime * _timeSpeedPaused;
            if (_timer >= _timerRound) {
                RoundIsDone();
                _timer = 0;
            }
        }
    }
}