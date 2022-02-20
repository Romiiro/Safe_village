using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PauseListener : MonoBehaviour
{
    [SerializeField] private PauseEvent _event;
    private IStopable[] _dependencies;


    public void Activate(bool isPaused) {
        foreach (var dependency in _dependencies) {
            dependency.Stop(isPaused);
        }
    }

    private void OnEnable() {
        _event.RegisterListener(this);
        _dependencies = GetComponents<IStopable>();
    }

    private void OnDisable() {
        _event.UnregisterListener(this);
    }
}
