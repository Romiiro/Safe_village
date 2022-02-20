using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour, IResCountDependency, IResetable {
    [SerializeField] private protected ResourcesSO _res;
    [SerializeField] private protected Timer _timer;
    [SerializeField] private protected Text _resCount;
    [SerializeField] private Image _imageTimer;

    private protected TooltipTextUI _tooltip;

    // Start is called before the first frame update
    private protected void Start() {
        _res.Reset();
        _tooltip = gameObject.GetComponent<TooltipTextUI>();
        if (_timer!=null) {
            _timer.RegisterListener(_res);
        }
    }

    public void UpdateTooltipMessage() {
        _tooltip.Message = _res.Title;
    }

    // Update is called once per frame
    private protected void Update() {
        if(_imageTimer!=null) {
            ChangeImageTimer();
        }
    }

    private void ChangeImageTimer() {
        _imageTimer.fillAmount = _timer.CurrentTimerFill();
    }

    public void OnChangeResValue() {
        _resCount.text = _res.Count.ToString();
    }

    public void Reset() {
        _res.Reset();
    }
}
