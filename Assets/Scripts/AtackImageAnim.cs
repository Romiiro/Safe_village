#region

using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// �������� ����������� �� ����� ����� 
/// </summary>
public class AtackImageAnim : MonoBehaviour {
    [SerializeField] private BattleManager _battleManager;
    [SerializeField] private BattleTimer _timer;
    private bool _isActive;
    [SerializeField] private Image _hp;
    [SerializeField] private Image _image;

    private int _startResCount;
    [SerializeField] private ResourcesSO _resourse;
    [SerializeField] private TooltipTextUI tooltipTextUI;

    public void StartAnimation() {
        _startResCount = _resourse.Count;
        _isActive = true;
    }

    public void StopAnimation() {
        _isActive = false;
    }

    /// <summary>
    /// �� ����� ����� ��� ���������� ������ �������� ������� �����(������) ����������� �������������� ����������� � ������� �� ������ ��������. 
    /// </summary>
    private void ChangeImage() {
        if (!_battleManager.InBattle) {
            _image.color = new Color(255, 255, 255, 0);
        }
        else if (_timer.CurrentTimerFill() < 0.5f) {
            _image.color = Color.Lerp(Color.clear, Color.white,
                _timer.CurrentTimerFill() * 2);
        }
        else {
            _image.color = Color.Lerp(Color.clear, Color.white,
                (1 - _timer.CurrentTimerFill()) * 2);
        }

        //����������� "��", ������������� �� ������� "���������� ������ �� ������ ������� �����"/"������� ���������� ������"
        _hp.fillAmount = (float) _resourse.Count / _startResCount;
        tooltipTextUI.Message = _resourse.Title + ": " + _resourse.Count;
    }

    private protected void FixedUpdate() {
        if (_isActive) ChangeImage();
    }
}