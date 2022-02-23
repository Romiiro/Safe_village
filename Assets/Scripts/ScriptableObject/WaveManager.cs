#region

using UnityEngine;

#endregion

[CreateAssetMenu(menuName = "ScriptableObject/WavesManager")]
public class WaveManager : ScriptableObject, IResetable {
    [SerializeField] private BattleManager _battleManager;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private float _timeToFirstWave;
    [SerializeField] private GameObject _encounterPrefab;
    [SerializeField] private GameSettings _settings;
    private int _currentWave = 1;
    [SerializeField] private int _lastWaveSize;
    [SerializeField] private int _wavesSize;
    [SerializeField] private ResourcesSO _enenySO;

    public bool FirstWave { get; set; }

    public float TimeBetweenWaves => _timeBetweenWaves;

    public float TimeToFirstWave => _timeToFirstWave;

    public int NextWaveCount { get; set; }

    public int WavesPassed { get; set; }

    public int WavesSize {
        get => _wavesSize;
        set => _wavesSize = value;
    }

    public void Reset() {
        WavesPassed = 0;
        FirstWave = true;
        NextWaveCount = WavesSize;
        _currentWave = 1;
    }

    public void OnTimerRound() {
        if (FirstWave) FirstWave = false;

        _enenySO.Count = NextWaveCount;
        _currentWave++;
        if (_currentWave < 10) {
            NextWaveCount = _wavesSize;
        } else if (_currentWave == 10) {
            NextWaveCount = _lastWaveSize;
        } else {
            NextWaveCount = 0;
        }
        
    }

    private void OnEnable() {
        FirstWave = true;
        NextWaveCount = WavesSize;
    }
}