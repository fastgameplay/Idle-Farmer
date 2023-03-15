using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] GameObject _attackArea;
    

    void Awake(){
        _attackArea.SetActive(false);
    }
    


    public void Attack(){
        StopAllCoroutines();
        StartCoroutine(IEattack());
    }
    IEnumerator IEattack(){
        Debug.Log("ATTACK Started");
        _attackArea.SetActive(true);
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        _attackArea.SetActive(false);
        Debug.Log("ATTACK Ended");
    }
}
