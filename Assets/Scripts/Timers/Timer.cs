#region

using System.Collections.Generic;
using UnityEngine;

#endregion


/// <summary>
/// Базовый класс таймера.
/// </summary>
public abstract class Timer : MonoBehaviour, IResetable, IStopable {
    [SerializeField] private float _startTimerRound;
    [SerializeField] private protected float _timer;
    private protected float _timerRound;
    [SerializeField] private protected GameSettings _settings;
    private protected int _timeSpeedPaused = 1;
    private protected List<ResourcesSO> _timerListener = new List<ResourcesSO>();

    public float StartTimerRound {
        get => _startTimerRound;
        set => _startTimerRound = value;
    }

    public float TimerRound {
        get => _timerRound;
        set => _timerRound = value;
    }

    public virtual void Reset() {
        _timerRound = _startTimerRound;
        _timer = 0;
    }

    public void Stop(bool isStoped) {
        _timeSpeedPaused = isStoped ? 0 : 1;
    }

    public float CurrentTimerFill() {
        return _timer / _timerRound;
    }

    public void RegisterListener(ResourcesSO listener) {
        _timerListener.Add(listener);
    }

    public abstract void RoundIsDone();

    private void FixedUpdate() {
        _timer += Time.deltaTime * _timeSpeedPaused;
        if (_timer >= _timerRound) {
            RoundIsDone();
            _timer = 0;
        }
    }


    private void Start() {
        _timer = 0;
        _timerRound = _startTimerRound;
        _timeSpeedPaused = 1;
    }
}