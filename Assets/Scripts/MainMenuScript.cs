using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    private AudioSource _audio;
    [SerializeField] private AudioSettings _audioSettings;

    private void Start() {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayButtonSound() {
        _audio.Play();
    } 
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
}
