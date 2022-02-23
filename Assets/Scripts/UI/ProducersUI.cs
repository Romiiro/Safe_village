#region

using UnityEngine;

#endregion

/// <summary>
/// Расширение интерфейса ресурсов, для производящих ресурсы ресурсов
/// </summary>
public class ProducersUI : ResourcesUI {
    [SerializeField] private ResourcesSO _producedRes;

    // Start is called before the first frame update
    private new void Start() {
        if (_timer != null) _timer.RegisterListener(_producedRes);
    }
}