using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Событие активации/деактивации паузы
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/Events/PauseEvent")]
public class PauseEvent : ScriptableObject {
    private List<PauseListener> _listeners = new List<PauseListener>();
    public void RegisterListener(PauseListener listener) {
        _listeners.Add(listener);
    }

    public void UnregisterListener(PauseListener listener) {
        _listeners.Remove(listener);
    }

    public void Rise(bool isPaused) {
        foreach (var listener in _listeners) {
            listener.Activate(isPaused);
        }
    }
}
