using System.Collections;
using System.Collections.Generic;using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class AtackImageAnim : MonoBehaviour {
    [SerializeField] private BattleTimer _timer;
    [SerializeField] private BattleManager _battleManager;
    [SerializeField] private ResourcesSO _resourse;
    [SerializeField] private Image _image;
    [SerializeField] private Image _hp;
    [SerializeField] private float a;
    [SerializeField] private TooltipTextUI tooltipTextUI;

    private bool _isActive;

    private int _startResCount;

    public void StartAnimation() {
        _startResCount = _resourse.Count;
        _isActive = true;
    }

    public void StopAnimation() {
        _isActive = false;
    }

    private protected void FixedUpdate() { 
        if (_isActive) {
                ChangeImage();
        }
    }

    private void ChangeImage() {
        if (!_battleManager.InBattle)
            _image.color = new Color(255, 255, 255, 0);
        else if (_timer.CurrentTimerFill() < 0.5f) {
            _image.color = Color.Lerp(Color.clear, Color.white, 
                _timer.CurrentTimerFill()*2);

            a = _image.color.a;
        }
        else {
            _image.color = Color.Lerp(Color.clear, Color.white, 
                (1 - _timer.CurrentTimerFill()) * 2);
            a = _image.color.a;
        }

        _hp.fillAmount = (float)_resourse.Count / _startResCount;
        tooltipTextUI.Message = _resourse.Title + ": " + _resourse.Count;
    }
}
