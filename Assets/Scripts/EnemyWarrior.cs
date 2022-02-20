using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : MonoBehaviour {
    [SerializeField] private GameObject _target;
    private GameSettings _settings;
    private float _speed;
    private bool _run = false;
    private Animator _anim;
    private bool _onTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _speed = _settings.WarriorSpeed * Random.Range(0.8f, 1/2f);
    }

    // Update is called once per frame
    void Update() {
        if (_target && !_onTarget) {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _speed);
           if (!_run) {
               _anim.Play("Base Layer.Male Sword Sprint");
               _run = true;
           }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == _target) {
            _onTarget = true;
            _anim.Play("Base Layer.Male Attack 1");
            _target.GetComponent<DefenderWarrior>().PlayAnimation("Base Layer.Male Attack 1");
        }
    }

    public void SetTarget(GameObject target, GameSettings settings) {
        _target = target;
        _settings = settings;
    }
}
