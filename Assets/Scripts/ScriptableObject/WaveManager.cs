using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/WavesManager")]
public class WaveManager : ScriptableObject, IResetable {
    [SerializeField] private float _timeToFirstWave;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private int _wavesSize;
    [SerializeField] private int _lastWaveSize;
    [SerializeField] private GameObject _encounterPrefab;
    [SerializeField] private GameSettings _settings;
    [SerializeField] private Units _units;
    [SerializeField] private ResourcesSO _enenySO;
    [SerializeField] private BattleManager _battleManager;

    private int _currentWave = 1;

    public float TimeToFirstWave {
        get => _timeToFirstWave;
    }

    public float TimeBetweenWaves {
        get => _timeBetweenWaves;
    }

    public int WavesSize {
        get => _wavesSize;
        set => _wavesSize = value;
    }

    public int WavesPassed { get; set; }
    public int NextWaveCount { get; set; }

    public bool FirstWave { get; set; }

    private void OnEnable() {
        FirstWave = true;
        NextWaveCount = WavesSize;
    }

    public void OnTimerRound() {
        if (FirstWave) {
            FirstWave = false;
        }

        _enenySO.Count = NextWaveCount;
        _currentWave ++;
        NextWaveCount = _currentWave == 10 ? _lastWaveSize : _wavesSize;


    }

    public void Reset() {
        WavesPassed = 0;
        FirstWave = true;
        NextWaveCount = WavesSize;
        _currentWave = 1;
    }
}
