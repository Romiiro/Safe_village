#region

using UnityEngine;

#endregion

/// <summary>
/// Таймер волн
/// </summary>
public class WavesTimer : Timer {
    [SerializeField] private BattleManager _battleManager;
    [SerializeField] private WaveManager _waveManager;

    public bool FirstWave { get; set; }

    public int TimeToWave() {
        return Mathf.RoundToInt(_timerRound - _timer);
    }


    /// <summary>
    /// Сброс таймера
    /// </summary>
    public override void Reset() {
        FirstWave = true;
        _timerRound = _waveManager.TimeToFirstWave;
        _battleManager.InBattle = false;
        _timer = 0;
    }
    
    public override void RoundIsDone() {
        if (FirstWave) {
            FirstWave = false;
            _timerRound = _waveManager.TimeBetweenWaves;
        }

        if (_waveManager.NextWaveCount == 0) {
            _timeSpeedPaused = 0;
        }
        _waveManager.OnTimerRound();
        if (!_battleManager.InBattle) _battleManager.StartBattle();
    }

    private void Start() {
        FirstWave = true;
        _timer = 0;
        _timerRound = _waveManager.TimeToFirstWave;
    }
}