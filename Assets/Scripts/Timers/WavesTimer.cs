using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesTimer : Timer {
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private BattleManager _battleManager;


    public bool FirstWave { get; set; }

    private void Start() {
        FirstWave = true;
        _timer = 0;
        _timerRound = _waveManager.TimeToFirstWave;
    }


    public override void RoundIsDone() {
        if (FirstWave) {
            FirstWave = false;
            _timerRound = _waveManager.TimeBetweenWaves;
        }
        _waveManager.OnTimerRound();
        if (!_battleManager.InBattle) {
            _battleManager.StartBattle();
        }
    }

    public int TimeToWave() {
        return Mathf.RoundToInt(_timerRound - _timer);
    }

    public override void Reset() {
        FirstWave = true;
        _timerRound = _waveManager.TimeToFirstWave;
        _battleManager.InBattle = false;
        _timer = 0;
    }
}
