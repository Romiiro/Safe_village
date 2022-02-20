using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeSettingListener : MonoBehaviour {
    [SerializeField] private ChangeSettingEvent _event;
    private AudioSettingsApplier _applier;

    public void OnEventRised() {
        _applier.ConfigureAudioSource();
    }

    private void OnEnable() {
        if (TryGetComponent<AudioSettingsApplier>(out _applier)) {
            _event.RegisterListener(this);
        }
    }

    private void OnDisable() {
        _event.UnregisterListener(this);
    }
}
