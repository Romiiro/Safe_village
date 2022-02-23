using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    /// <summary>
    /// UI ������������ ���������� � ������. ��������� ����� UI ���������� � ��������.
    /// </summary>
public class EncounterUI : ResourcesUI, IResetable {
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private Text _nextWaveCountText;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _wavesCounterText;

    private void Update() {
        base.Update();
        _timerText.text = ((WavesTimer) _timer).TimeToWave().ToString();
        _nextWaveCountText.text = _waveManager.NextWaveCount.ToString();
        _wavesCounterText.text = _waveManager.WavesPassed.ToString() + " �� 10";
    }

    public new void Reset() {
        _waveManager.Reset();
    }
}
