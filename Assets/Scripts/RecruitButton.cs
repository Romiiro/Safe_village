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
                      "Стоимость найма(еда): " + resourceToRecruit.RecruitCost.ToString() +
                      "\n\n";
        if (resourceToRecruit.Type == ResourceType.Baker) {
            _tooltipMsg += "Производит " + resourceToRecruit.ProductionPerUnit + " печенки, каждые " +
                           resourceToRecruit.IncreaseTime + " секунд";
        } else if (resourceToRecruit.Type == ResourceType.Elf) {
            _tooltipMsg += "Потребляет " + resourceToRecruit.ConsumeValuePerUnit + "печенек, каждые 7 секунд";
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
            tooltipText.Message = "Недостаточно еды для найма.\n\n" +
                                  _tooltipMsg;
        } else if (!_timer.TimerIsOn) {
            _button.interactable = true;
            tooltipText.Message = _tooltipMsg;
        }
    }
}

