using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ChangeSettingsEvent")]
public class ChangeSettingEvent : ScriptableObject {
    private List<ChangeSettingListener> listeners = new List<ChangeSettingListener>();

    public void Rise() {
        for (int i = 0; i < listeners.Count; i++) {
            listeners[i].OnEventRised();
        }
    }

    public void RegisterListener(ChangeSettingListener listener) {
        listeners.Add(listener);
    }

    public void UnregisterListener(ChangeSettingListener listener) {
        listeners.Remove(listener);
    }

}
