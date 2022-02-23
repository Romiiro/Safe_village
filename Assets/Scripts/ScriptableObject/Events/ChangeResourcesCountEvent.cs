using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Событие изменения количества ресурсов
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/Events/ChangeResourcesEvent")]
public class ChangeResourcesCountEvent : ScriptableObject {
    private List<ChangeResourcesListener> _listeners = new List<ChangeResourcesListener>();

    public void RegisterListener(ChangeResourcesListener listener) {
        _listeners.Add(listener);
    }

    public void UnRegisterListener(ChangeResourcesListener listener) {
        _listeners.Remove(listener);
    }

    public void Rise() {
        foreach (var listener in _listeners) {
            listener.Activate();
        }
    }
}
