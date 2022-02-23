#region

using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// ����� ����������� ���������� ������ �����.
/// </summary>
public class RecruitButton : MonoBehaviour, IResCountDependency {
    private Button _button;
    [SerializeField] private Image _recruitRollback;
    [SerializeField] private RecruitTimer _timer;
    [SerializeField] private ResourcesSO _consumedResource;
    [SerializeField] private ResourcesSO resourceToRecruit;
    private string _tooltipMsg;
    [SerializeField] private TooltipTextUI tooltipText;

    /// <summary>
    /// ��� ��������� �������� �������� �������� ������������ ������
    /// </summary>
    public void OnChangeResValue() {
        ActivateButton();
    }

    /// <summary>
    /// ���������� ������ �����, ���� ���������� �������� � ��� ������, ����� ����������� �����.
    /// </summary>
    public void ActivateButton() {
        if (_button == null) return;
        _timer.TimerRound = resourceToRecruit.TimeToRecruit;
        if (resourceToRecruit.RecruitCost > _consumedResource.Count) {
            _button.interactable = false;
            tooltipText.Message = "������������ ��� ��� �����.\n\n" +
                                  _tooltipMsg;
        }
        else if (!_timer.TimerIsOn) {
            _button.interactable = true;
            tooltipText.Message = _tooltipMsg;
        }
    }
    
    private void Start() {
        _button = GetComponent<Button>();
        ActivateButton();
        _timer.StartTimerRound = resourceToRecruit.TimeToRecruit;
        // ������ ����� ����������� ��������� � ����������� �� ���� ������������ �������.
        _tooltipMsg = resourceToRecruit.Title +
                      "\n\n" +
                      "��������� �����(���): " + resourceToRecruit.RecruitCost.ToString() +
                      "\n\n";
        if (resourceToRecruit.Type == ResourceType.Baker)
            _tooltipMsg += "���������� " + resourceToRecruit.ProductionPerUnit + " �������, ������ " +
                           resourceToRecruit.IncreaseTime + " ������";
        else if (resourceToRecruit.Type == ResourceType.Elf)
            _tooltipMsg += "���������� " + resourceToRecruit.ConsumeValuePerUnit + " �������, ������ 7 ������";

        tooltipText.Message = _tooltipMsg;
    }

    private void Update() {
        _recruitRollback.fillAmount = _timer.CurrentTimerFill();
    }
}