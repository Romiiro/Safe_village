using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Событие окончания игры
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/Events/EndGameEvent")]
public class EndGameEvent : ScriptableObject {
    private List<EndGameListener> _listeners = new List<EndGameListener>();

    public void Rise(EndGameCode code) {
        foreach (var listener in _listeners) {
            listener.OnEventRised(code);
        }
    }

    public void RegisterListener(EndGameListener listener) {
        _listeners.Add(listener);
    }

    public void UnregisterListener(EndGameListener listener) {
        _listeners.Remove(listener);
    }

}
