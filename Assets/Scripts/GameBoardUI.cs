using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBoardUI : MonoBehaviour {

    [SerializeField] private PauseEvent _pauseEvent;
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private EndGameTextSwitcher _endGameText;
    public void EndGame(EndGameStatus status) {
        _pauseEvent.Rise(true);
        _endGameMenu.SetActive(true);
        _endGameText.DisplayText(status);
    }

    private void Start() {
        _pauseEvent.Rise(true);
    }

    public void EndGame() {
        SceneManager.LoadScene("MainMenu");
    }
}
