using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameListener : MonoBehaviour {
    [SerializeField] private EndGameEvent _event;

    private void OnEnable() {
        _event.RegisterListener(this);
    }

    private void OnDisable() {
        _event.UnregisterListener(this);
    }

    public void OnEventRised(EndGameStatus status) {
        GetComponent<GameBoardUI>().EndGame(status);
    }
}
