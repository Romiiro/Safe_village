using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Events/EndGameEvent")]
public class EndGameEvent : ScriptableObject
{
    private List<EndGameListener> listeners = new List<EndGameListener>();

    public void Rise(EndGameStatus status) {
        for (int i = 0; i < listeners.Count; i++) {
            listeners[i].OnEventRised(status);
        }
    }

    public void RegisterListener(EndGameListener listener) {
        listeners.Add(listener);
    }

    public void UnregisterListener(EndGameListener listener) {
        listeners.Remove(listener);
    }

}
