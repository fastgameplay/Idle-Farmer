using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlantHolder))]
public class FieldCell : MonoBehaviour
{
    PlantHolder _plantHolder;
    GameObject _dropPrefab;
    void Awake(){
    }

    public void SetUp(PlantScriptable plantData, GameObject dropPrefab){
        _plantHolder = GetComponent<PlantHolder>();
        _plantHolder.InstantiateCrop(plantData);
        _dropPrefab = dropPrefab;
    }

    public void Chop(){
        if(_plantHolder.IsGrown){
            Instantiate(_dropPrefab,transform.position, Quaternion.identity);
            _plantHolder.Chop();
        }
    }
}
