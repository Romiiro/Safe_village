using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class ChangeResourcesListener : MonoBehaviour {
    private IResCountDependency _dependency;
    [SerializeField] private ChangeResourcesCountEvent _event;
    public void Activate() {
        _dependency.OnChangeResValue();
    }

    private void OnEnable() {
        _event.RegisterListener(this);
        _dependency = GetComponent<IResCountDependency>();
        _event.Rise();
    }

    private void OnDisable() {
        _event.UnRegisterListener(this);
    }

}
