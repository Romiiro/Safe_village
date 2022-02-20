using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Events/ChangeResourcesEvent")]
public class ChangeResourcesCountEvent : ScriptableObject {
    private List<ChangeResourcesListener> listeners = new List<ChangeResourcesListener>();

    public void RegisterListener(ChangeResourcesListener listener) {
        listeners.Add(listener);
    }

    public void UnRegisterListener(ChangeResourcesListener listener) {
        listeners.Remove(listener);
    }

    public void Rise() {
        foreach (var listener in listeners) {
            listener.Activate();
        }
    }
}
