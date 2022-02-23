#region

using UnityEngine;
using UnityEngine.UI;

#endregion


/// <summary>
/// Меню настроек.
/// </summary>
public class SettingsMenuScript : MonoBehaviour {
    [SerializeField] private AudioSettings _audioSettings;
    private AudioSource _audio;
    [SerializeField] private Slider _generalVolumeSlider;
    [SerializeField] private Slider _interfaceVolumeSlider;
    [SerializeField] private Slider _surroundVolumeSlider;
    [SerializeField] private Toggle _muteSound;

    public void PlayButtonSound() {
        if(_audio!= null)
            _audio.Play();
    }

    private void ChangeVolume(AudioType type, float value) {
        switch (type) {
            case AudioType.General: {
                _audioSettings.GeneralVolume = value;
                break;
            }
            case AudioType.Interface: {
                _audioSettings.InterfaceVolume = value;
                break;
            }
            case AudioType.Surround: {
                _audioSettings.SurroundVolume = value;
                break;
            }
        }
    }

    private void MuteSound(bool value) {
        _audioSettings.MuteSound = value;
    }

    private void Start() {
        TryGetComponent<AudioSource>(out _audio);

        _muteSound.isOn = _audioSettings.MuteSound;
        _generalVolumeSlider.value = _audioSettings.GeneralVolume;
        _surroundVolumeSlider.value = _audioSettings.SurroundVolume;
        _interfaceVolumeSlider.value = _audioSettings.InterfaceVolume;

        _muteSound.onValueChanged.AddListener(MuteSound);
        _generalVolumeSlider.onValueChanged.AddListener(delegate {
            ChangeVolume(AudioType.General, _generalVolumeSlider.value);
        });
        _surroundVolumeSlider.onValueChanged.AddListener(delegate {
            ChangeVolume(AudioType.Surround, _surroundVolumeSlider.value);
        });
        _interfaceVolumeSlider.onValueChanged.AddListener(delegate {
            ChangeVolume(AudioType.Interface, _interfaceVolumeSlider.value);
        });
    }
}