using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTimer : Timer {

    [SerializeField] private BattleManager _battleManager;
    private bool _timerIsOn;

    public bool TimerIsOn {
        get => _timerIsOn;
        set => _timerIsOn = value;
    }

    public override void RoundIsDone() {
        _battleManager.OnTimerRound(); 
    }

    private void FixedUpdate() {
        if (_battleManager.InBattle) {
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
}
