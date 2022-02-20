using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Unit/UnitPosition")]
public class UnitPosition : ScriptableObject {
    [SerializeField] private List<Vector3> _coords;
    private int lastGivenPos = 0;
    [SerializeField] private int _unitSize = 3;
    [SerializeField] private bool isDefenders;
    private float _maxYValue;
    private float _minYValue;

    public float MaxYValue {
        get => _maxYValue;
        set => _maxYValue = value;
    }

    public float MinYValue {
        get => _minYValue;
        set => _minYValue = value;
    }
    public void SetFirstPosition(Vector3 value) {
        _coords.Add(value);
    }

    private void OnEnable() {
        _coords = new List<Vector3>();
        lastGivenPos = 0;
    }

    public Vector3 GetNextPosition() {
        if (_coords.Count <= lastGivenPos) {
            GeneratePositon();
        }
        return _coords[lastGivenPos++];
    }

    private void GeneratePositon() {
        float x = _coords[lastGivenPos-1].x;
        for (float y = _coords[0].y + _unitSize; y < _maxYValue; y += _unitSize) {
            _coords.Add(new Vector3(x,y,-0.6f));
        }
        for (float y = _coords[0].y - _unitSize; y > _minYValue; y -= _unitSize) {
            _coords.Add(new Vector3(x, y, -0.6f));
        }
        if(isDefenders) {
            _coords.Add(new Vector3(x - _unitSize, _coords[0].y, -0.6f));
        }
        else {
            _coords.Add(new Vector3(x + _unitSize, _coords[0].y, -0.6f));
        }
    }

}
