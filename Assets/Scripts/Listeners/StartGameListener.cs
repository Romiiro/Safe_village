using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class StartGameListener : MonoBehaviour
{
    private IResetable[] _dependencies;
    [SerializeField] private StartGameEvent _event;
    public void OnEventRised() {
        foreach (var dependency in _dependencies) {
            dependency.Reset();
        }
    }

    private void OnEnable() {
        _event.RegisterListener(this);
        _dependencies = GetComponents<IResetable>();
    }

    private void OnDisable() {
        _event.UnregisterListener(this);
    }
}
