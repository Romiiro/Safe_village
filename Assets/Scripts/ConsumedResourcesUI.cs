using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumedResourcesUI : ResourcesUI {
    [SerializeField] private ResourcesSO _consumer;
    [SerializeField] private ResourcesSO _producer;

    private new void Update() {
        UpdateTooltipMessage();
        base.Update();
    }
    public new void UpdateTooltipMessage() {
        string msg;
        int consume = _consumer.ConsumeValue;
        int produce = _producer.ProductionValue;
        msg = _res.Title + "\n\nПотребление:" + (consume*1);
        _tooltip.Message = msg;
    }

}
