using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class GoldTextAnim : MonoBehaviour
{
    Animator _animator;
    void Awake(){
        _animator = GetComponent<Animator>();
    }
    public void PlayShake(){
        _animator.Play("GoldText_Shake");
    }
}
