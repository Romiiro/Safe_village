#region

using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// Класс описывающий отображение ресурса.
/// </summary>
public class ResourcesUI : MonoBehaviour, IResCountDependency, IResetable {
    [SerializeField] private Image _imageTimer;
    [SerializeField] private protected ResourcesSO _res;
    [SerializeField] private protected Text _resCount;
    [SerializeField] private protected Timer _timer;

    private protected TooltipTextUI _tooltip;

    public void OnChangeResValue() {
        _resCount.text = _res.Count.ToString();
    }

    public void Reset() {
        _res.Reset();
    }

    public void UpdateTooltipMessage() {
        _tooltip.Message = _res.Title;
    }

    private void ChangeImageTimer() {
        _imageTimer.fillAmount = _timer.CurrentTimerFill();
    }

    // Start is called before the first frame update
    private protected void Start() {
        _res.Reset();
        _tooltip = gameObject.GetComponent<TooltipTextUI>();
        if (_timer != null) _timer.RegisterListener(_res);
    }

    // Update is called once per frame
    private protected void Update() {
        if (_imageTimer != null) ChangeImageTimer();
    }
}