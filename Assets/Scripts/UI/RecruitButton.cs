#region

using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// Класс описывающий функционал кнопки найма.
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
    /// При изменении значения ресурсов пытается активировать кнопку
    /// </summary>
    public void OnChangeResValue() {
        ActivateButton();
    }

    /// <summary>
    /// Активирует кнопку найма, если достаточно ресурсов и нет отката, после предыдущего найма.
    /// </summary>
    public void ActivateButton() {
        if (_button == null) return;
        _timer.TimerRound = resourceToRecruit.TimeToRecruit;
        if (resourceToRecruit.RecruitCost > _consumedResource.Count) {
            _button.interactable = false;
            tooltipText.Message = "Недостаточно еды для найма.\n\n" +
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
        // Меняет тескт всплывающей подсказки в зависимости от типа создаваемого ресурса.
        _tooltipMsg = resourceToRecruit.Title +
                      "\n\n" +
                      "Стоимость найма(еда): " + resourceToRecruit.RecruitCost.ToString() +
                      "\n\n";
        if (resourceToRecruit.Type == ResourceType.Baker)
            _tooltipMsg += "Производит " + resourceToRecruit.ProductionPerUnit + " печенки, каждые " +
                           resourceToRecruit.IncreaseTime + " секунд";
        else if (resourceToRecruit.Type == ResourceType.Elf)
            _tooltipMsg += "Потребляет " + resourceToRecruit.ConsumeValuePerUnit + " печенек, каждые 7 секунд";

        tooltipText.Message = _tooltipMsg;
    }

    private void Update() {
        _recruitRollback.fillAmount = _timer.CurrentTimerFill();
    }
}