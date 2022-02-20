using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConsumptionTimer : Timer {
    [SerializeField] private List<ResourcesSO> _consumer;
    [SerializeField] private AudioSource _consumeSound;

    public override void RoundIsDone() {
        int consumeValue = _consumer.Sum(t => t.ConsumeValue) * -1;
        _consumeSound.Play();
        foreach (var listener in _timerListener) {
            listener.AddResources(consumeValue);
        }
    }
}
