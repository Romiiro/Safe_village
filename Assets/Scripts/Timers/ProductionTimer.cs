using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProductionTimer : Timer {
    [SerializeField] private List<ResourcesSO> _producers;
    [SerializeField] private AudioSource _harvestSound;

public override void RoundIsDone() {
    int productionValue = _producers.Sum(t => t.ProductionValue);
    _harvestSound.Play();
    foreach (var listener in _timerListener) {
        listener.AddResources(productionValue);
    }
    }
}
