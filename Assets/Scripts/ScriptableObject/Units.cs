using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Unit/Units")]
public class Units : ScriptableObject {
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private UnitPosition _unitPositions;
    [SerializeField] private Units _enemyUnits;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private GameSettings _settings;

    private List<GameObject> _units;
    private int currentTarget;

    private void OnEnable() {
        _units = new List<GameObject>();
        currentTarget = 0;
    }


    public void Attack() {
        foreach (var unit in _units) {
            Animator anim = unit.GetComponent<Animator>();
            anim.Play("Base Layer.Male Attack 2");
            
        }
    }

    public GameObject GetNextTarget() {
        if (currentTarget < _units.Count)
            return _units[currentTarget++];
        return null;
    }
}
