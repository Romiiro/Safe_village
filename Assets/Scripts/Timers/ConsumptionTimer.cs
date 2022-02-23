#region

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

public class ConsumptionTimer : Timer {
    [SerializeField] private AudioSource _consumeSound;
    [SerializeField] private List<ResourcesSO> _consumer;

    public override void RoundIsDone() {
        var consumeValue = _consumer.Sum(t => t.ConsumeValue) * -1;
        _consumeSound.Play();
        foreach (var listener in _timerListener) {
            listener.AddResources(consumeValue);
        }
    }
}