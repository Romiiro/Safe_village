using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {
    [SerializeField] private ResourcesSO _defenders;

    [SerializeField] private ResourcesSO _enemy;

    [SerializeField] private WaveManager _waveManager;

    [SerializeField] private GameSettings _gameSettings;

    [SerializeField] private BattleTimer _battleTimer;

    [SerializeField] private EndGameEvent _endGameEvent;

    [SerializeField] private AudioSource _battleSound;

    [SerializeField] private List<AtackImageAnim> _anims;



    
    public bool InBattle { get; set; }

    private void Start() {
        InBattle = false;
        
    }

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

    public void PlaySound() {
        if (!_battleSound.isPlaying) {
            _battleSound.time = 0;
            _battleSound.Play();
        }
    }

    public void OnTimerRound() {
        if (_defenders.Count == 0 && _enemy.Count > 0) {
            StopBatle();
            _endGameEvent.Rise(EndGameStatus.Defeat);
        }
        _enemy.Count -= 1;
        _defenders.Count -= 1;
        if (_enemy.Count == 0 ) {
            StopBatle();
            _waveManager.WavesPassed++;
            if (_waveManager.WavesPassed >= _gameSettings.WavesToWin) {
                _endGameEvent.Rise(EndGameStatus.Win);
            }
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


    
}
