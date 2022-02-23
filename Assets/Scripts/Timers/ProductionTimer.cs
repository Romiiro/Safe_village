#region

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

public class ProductionTimer : Timer {
    [SerializeField] private AudioSource _harvestSound;
    [SerializeField] private List<ResourcesSO> _producers;

    public override void RoundIsDone() {
        var productionValue = _producers.Sum(t => t.ProductionValue);
        _harvestSound.Play();
        foreach (var listener in _timerListener) {
            listener.AddResources(productionValue);
        }
    }
}