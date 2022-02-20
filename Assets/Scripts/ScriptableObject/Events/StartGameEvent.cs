using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Events/StartGameEvent")]
public class StartGameEvent : ScriptableObject
{
    private List<StartGameListener> listeners = new List<StartGameListener>();

    public void Rise() {
        for (int i = 0; i < listeners.Count; i++) {
            listeners[i].OnEventRised();
        }
    }

    public void RegisterListener(StartGameListener listener) {
        listeners.Add(listener);
    }

    public void UnregisterListener(StartGameListener listener) {
        listeners.Remove(listener);
    }
}
