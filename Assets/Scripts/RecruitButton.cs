using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitButton : MonoBehaviour, IResCountDependency {
    [SerializeField] private ResourcesSO _consumedResource;
    [SerializeField] private RecruitTimer _timer;
    [SerializeField] private ResourcesSO resourceToRecruit;
    [SerializeField] private TooltipTextUI tooltipText;
    [SerializeField] private Image _recruitRollback;

    private string _tooltipMsg;

    private Button _button;

    private void Start() {
        _button = GetComponent<Button>();
        _timer.StartTimerRound = resourceToRecruit.TimeToRecruit;
        _tooltipMsg = resourceToRecruit.Title + 
                      "\n\n" +
                      "��������� �����(���): " + resourceToRecruit.RecruitCost.ToString() +
                      "\n\n";
        if (resourceToRecruit.Type == ResourceType.Baker) {
            _tooltipMsg += "���������� " + resourceToRecruit.ProductionPerUnit + " �������, ������ " +
                           resourceToRecruit.IncreaseTime + " ������";
        } else if (resourceToRecruit.Type == ResourceType.Elf) {
            _tooltipMsg += "���������� " + resourceToRecruit.ConsumeValuePerUnit + "�������, ������ 7 ������";
        }

        tooltipText.Message = _tooltipMsg;
    }
    
    public void OnChangeResValue() {
        ActivateButton();
    }

    private void Update() {
        _recruitRollback.fillAmount = _timer.CurrentTimerFill();
    }

    public void ActivateButton() {
        if (_button == null) return;
        _timer.TimerRound = resourceToRecruit.TimeToRecruit;
        if (resourceToRecruit.RecruitCost > _consumedResource.Count) {
            _button.interactable = false;
            tooltipText.Message = "������������ ��� ��� �����.\n\n" +
                                  _tooltipMsg;
        } else if (!_timer.TimerIsOn) {
            _button.interactable = true;
            tooltipText.Message = _tooltipMsg;
        }
    }
}

