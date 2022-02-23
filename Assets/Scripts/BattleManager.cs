#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public class BattleManager : MonoBehaviour, IStopable {
    [SerializeField] private AudioSource _battleSound;
    [SerializeField] private BattleTimer _battleTimer;
    [SerializeField] private EndGameEvent _endGameEvent;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private List<AtackImageAnim> _anims;
    [SerializeField] private ResourcesSO _defenders;
    [SerializeField] private ResourcesSO _enemy;
    [SerializeField] private WaveManager _waveManager;

    public bool InBattle { get; set; }

    public void Stop(bool isStoped) {
        if (isStoped && _battleSound.isPlaying)
            _battleSound.Pause();
        else if (InBattle) _battleSound.Play();
    }

    /// <summary>
    /// Метод срабатывающий при завершении цикла таймера битвы(раунда). Каждый раунд уменьшает число нападющих и защищающихся на 1.
    /// </summary>
    public void OnTimerRound() {
        // Если защитников не осталось, а враги еще есть вызывает событие окончания игры с кодом проигрыша.
        if (_defenders.Count == 0 && _enemy.Count > 0) {
            StopBatle();
            _endGameEvent.Rise(EndGameCode.Defeat);
        }

        _enemy.Count -= 1;
        _defenders.Count -= 1;
        if (_enemy.Count == 0) {
            StopBatle();
            _waveManager.WavesPassed++;
            if (_waveManager.WavesPassed >= _gameSettings.WavesToWin) _endGameEvent.Rise(EndGameCode.Win);
        }
    }

    /* public void PlaySound() {
         if (!_battleSound.isPlaying) {
             _battleSound.time = 0;
             _battleSound.Play();
         }
     } */


    public void StartBattle() {
        InBattle = true;
        if (!_battleSound.isPlaying) {
            _battleSound.time = 0;
            _battleSound.Play();
        }

        foreach (var anim in _anims) {
            anim.gameObject.SetActive(true);
            anim.StartAnimation();
        }
    }

    public void StopBatle() {
        InBattle = false;
        _battleSound.Stop();
        foreach (var anim in _anims) {
            anim.StopAnimation();
            anim.gameObject.SetActive(false);
        }
    }

    private void Start() {
        InBattle = false;
    }
}