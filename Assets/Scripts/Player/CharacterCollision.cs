using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterBackPack))]
public class CharacterCollision : MonoBehaviour
{
    CharacterBackPack _backPack;
    void Awake(){
        _backPack = GetComponent<CharacterBackPack>();
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("WheatPickable")){
            if(!_backPack.IsMax){
                Destroy(other.gameObject);
                _backPack.Quantity++;
            }
        }
    }
}
