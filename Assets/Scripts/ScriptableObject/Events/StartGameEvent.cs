using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Событие начала игры
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/Events/StartGameEvent")]
public class StartGameEvent : ScriptableObject {
    private List<StartGameListener> _listeners = new List<StartGameListener>();

    public void Rise() {
        for (int i = 0; i < _listeners.Count; i++) {
            _listeners[i].OnEventRised();
        }
    }

    public void RegisterListener(StartGameListener listener) {
        _listeners.Add(listener);
    }

    public void UnregisterListener(StartGameListener listener) {
        _listeners.Remove(listener);
    }
}
