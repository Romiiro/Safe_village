using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(menuName = "ScriptableObject/Events/PauseEvent")]
public class PauseEvent : ScriptableObject {
    private List<PauseListener> listeners = new List<PauseListener>();
    public void RegisterListener(PauseListener listener) {
        listeners.Add(listener);
    }

    public void UnregisterListener(PauseListener listener) {
        listeners.Remove(listener);
    }

    public void Rise(bool isPaused) {
        foreach (var listener in listeners) {
            listener.Activate(isPaused);
        }
    }
}
