#region

using UnityEngine;

#endregion

/// <summary>
/// UI потребляемых ресурсов. Расширение класса описывающиего интерфейс ресурсов для отображения всплывающей подсказки.
/// </summary>
public class ConsumedResourcesUI : ResourcesUI {
    [SerializeField] private ResourcesSO _consumer;
    [SerializeField] private ResourcesSO _producer;

    public new void UpdateTooltipMessage() {
        var consume = _consumer.ConsumeValue;
        var produce = _producer.ProductionValue;
        var msg = _res.Title + "\n\nПотребление:" + consume;
        _tooltip.Message = msg;
    }

    private new void Update() {
        UpdateTooltipMessage();
        base.Update();
    }
}