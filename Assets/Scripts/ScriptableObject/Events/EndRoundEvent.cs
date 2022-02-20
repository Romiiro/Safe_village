using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Events/EndRoundEvent")]
public class EndRoundEvent : ScriptableObject {
    private List<EndRoundListener> listeners = new List<EndRoundListener>();

    public void RegisterListener(EndRoundListener listener) {
        listeners.Add(listener);
    }

    public void UnregisterListener(EndRoundListener listener) {
        listeners.Remove(listener);
    }

    public void Rise() {
        foreach (var listener in listeners) {
            listener.OnEventRised();
        }
    }
}
