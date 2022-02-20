using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderWarrior : MonoBehaviour
{
    private Animator _anim;
    
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation(string animation) {
        _anim.Play("Base Layer.Male Attack 1");
    }
}
