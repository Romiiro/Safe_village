#region

using UnityEngine;

#endregion

/// <summary>
/// Таймер битвы(раунда)
/// </summary>
public class BattleTimer : Timer {
    [SerializeField] private BattleManager _battleManager;
    
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
}