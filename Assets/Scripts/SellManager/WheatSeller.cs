using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WheatSeller : MonoBehaviour
{
    [SerializeField] float _timeBetweenSell;
    [SerializeField] CharacterBackPack _backPack;
    [SerializeField] CoinThrower _coinThrower;
    public void StartSelling(){
        Debug.Log("StartSell");
        StopSelling();
        StartCoroutine(IESellProcess());
    }
    public void StopSelling(){
        StopAllCoroutines();
    }
    IEnumerator IESellProcess(){
        while (_backPack.Quantity > 0){
            _backPack.Quantity--;
            _coinThrower.AddCoin();
            yield return new WaitForSeconds(_timeBetweenSell);
        }
    }
}
