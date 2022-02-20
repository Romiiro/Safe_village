using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Resource")]
public class ResourcesSO : ScriptableObject, IResetable {
    [SerializeField] private int _startCount;
    [SerializeField] private int _startIncreaseCount;
    [SerializeField] private float _startIncreaseTime;
    [SerializeField] private int _startTimeToRecruit;
    [SerializeField] private int _startConsumeValuePerUnit;
    [SerializeField] private int _startProductionPerUnit;
    [SerializeField] private int _startMultiplyRecruit;
    [SerializeField] private int _startRecruitCost;
    [SerializeField] private ChangeResourcesCountEvent _event;
    [SerializeField] private EndGameEvent _endGameEvent;
    [SerializeField] private int _consumeValuePerUnit;
    [SerializeField] private int _productionPerUnit;
    [SerializeField] private int _timeToRecruit;
    [SerializeField] private int _multiplyRecruit;
    [SerializeField] private int _recruitCost;
    [SerializeField] private string _title;
    [SerializeField] private ResourceType _type;

    private int _count;
    private int _increaseCount;
    private float _increaseTime;

    #region Properties

    public ResourceType Type => _type;

    /// <summary>
    /// Resources quantity
    /// </summary>
    public int Count {
        get => _count;
        set {
            if (value < 0 && _endGameEvent != null) {
                _count = value;
                _endGameEvent.Rise(EndGameStatus.EndOfFood);
            }
            else if (value <0) {
                _count = 0;
            }
            else {
                _count = value;
            }
            if (_event != null) {
                _event.Rise();
            }
        }
    }

    /// <summary>
    /// Resource growth per cycle
    /// </summary>
    public int IncreaseCount {
        get => _increaseCount;
        set =>_increaseCount = value;
    }
    /// <summary>
    /// Resource growth cycle time
    /// </summary>
    public float IncreaseTime {
        get => _increaseTime;
        set => _increaseTime = value;
    }
    /// <summary>
    /// Consumption per unit
    /// </summary>
    public int ConsumeValuePerUnit {
        get => _consumeValuePerUnit;
        set => _consumeValuePerUnit = value;
    }
    /// <summary>
    /// Summary consumption per cycle
    /// </summary>
    public int ConsumeValue => ConsumeValuePerUnit * Count;

    /// <summary>
    ///  Production per unit
    /// </summary>
    public int ProductionPerUnit {
        get => _productionPerUnit;
        set => _productionPerUnit = value;
    }

    public int TimeToRecruit {
        get => _timeToRecruit;
        set => _timeToRecruit = value;
    }

    public int MultiplyRecruit {
        get => _multiplyRecruit;
        set => _multiplyRecruit = value; 
    }

    /// <summary>
    /// Summary production per cycle
    /// </summary>
    public int ProductionValue => Count * ProductionPerUnit;

    public int RecruitCost {
        get => _recruitCost;
        set => _recruitCost = value;
    }

    public string Title => _title;

    #endregion

    private void OnEnable() {
        Count = _startCount;
        _increaseCount = _startIncreaseCount;
        _increaseTime = _startIncreaseTime;
    }
    
    public void AddResources() {
        Count += _increaseCount;
    }

    public void AddResources(int value) {
        Count += value;
    }

    public void DecreaseResource(int value) {
        Count -= value;
    }

    public void DecreaseResource(ResourcesSO value) {
        Count -= value.RecruitCost;
    }

    public void Reset() {
        Count = _startCount;
        IncreaseCount = _startIncreaseCount;
        ConsumeValuePerUnit = _startConsumeValuePerUnit;
        ProductionPerUnit = _startProductionPerUnit;
        TimeToRecruit = _startTimeToRecruit;
        MultiplyRecruit = _startMultiplyRecruit;
        RecruitCost = _startRecruitCost;
    }
}
