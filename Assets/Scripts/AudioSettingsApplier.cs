using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSettingsApplier : MonoBehaviour
{
    [SerializeField] private AudioSettings _config;
    [SerializeField] private AudioType _type;

    private AudioSource _audio;

    private float _trackStartVolume;

    private void OnValidate() {
        ConfigureAudioSource();
    }

    private void Start() {
        if(TryGetComponent<AudioSource>(out _audio)){
            _trackStartVolume = _audio.volume;
            ConfigureAudioSource();
        }
    }

    public void ConfigureAudioSource() {
        if (_config != null) {
            _config.AudioConfigApply(_audio, _type, _trackStartVolume);
        }
    }
}
