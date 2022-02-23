#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class MainMenuScript : MonoBehaviour {
    [SerializeField] private AudioSettings _audioSettings;
    private AudioSource _audio;

    public void PlayButtonSound() {
        _audio.Play();
    }

    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }

    private void Start() {
        _audio = GetComponent<AudioSource>();
    }
}