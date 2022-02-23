#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class GameBoardUI : MonoBehaviour {
    [SerializeField] private EndGameTextSwitcher _endGameText;
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private PauseEvent _pauseEvent;

    /// <summary>
    /// При окончании игры останавливает игру, активирует меню и выводит отображает текст.
    /// </summary>
    /// <param name="code"></param>
    public void EndGame(EndGameCode code) {
        _pauseEvent.Rise(true);
        _endGameMenu.SetActive(true);
        _endGameText.DisplayText(code);
    }

    public void ExitGame() {
        SceneManager.LoadScene("MainMenu");
    }

    private void Start() {
        _pauseEvent.Rise(true);
    }
}