using UnityEngine;

/// <summary>
/// Ќаблюдатель за событием изменени€ ресурсов
/// </summary>
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
