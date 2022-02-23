using UnityEngine;

/// <summary>
/// Ќаблюдатель за событием окончани€ игры
/// </summary>
public class EndGameListener : MonoBehaviour {
    [SerializeField] private EndGameEvent _event;

    private void OnEnable() {
        _event.RegisterListener(this);
    }

    private void OnDisable() {
        _event.UnregisterListener(this);
    }

    public void OnEventRised(EndGameCode code) {
        GetComponent<GameBoardUI>().EndGame(code);
    }
}
