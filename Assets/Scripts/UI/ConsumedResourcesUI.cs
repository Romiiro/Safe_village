#region

using UnityEngine;

#endregion

/// <summary>
/// UI ������������ ��������. ���������� ������ ������������� ��������� �������� ��� ����������� ����������� ���������.
/// </summary>
public class ConsumedResourcesUI : ResourcesUI {
    [SerializeField] private ResourcesSO _consumer;
    [SerializeField] private ResourcesSO _producer;

    public new void UpdateTooltipMessage() {
        var consume = _consumer.ConsumeValue;
        var produce = _producer.ProductionValue;
        var msg = _res.Title + "\n\n�����������:" + consume;
        _tooltip.Message = msg;
    }

    private new void Update() {
        UpdateTooltipMessage();
        base.Update();
    }
}