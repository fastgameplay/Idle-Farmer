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
            Instantiate(_dropPrefab,transform.position + RandomVector(new Vector3(0.1f,0.05f,0.1f)), Quaternion.Euler(new Vector3(0,Random.Range(-15,15),0)));
            _plantHolder.Chop();
        }
    }

    Vector3 RandomVector(Vector3 range){
        return new Vector3(
            Random.Range(-range.x,range.x),
            Random.Range(-range.y,range.y),
            Random.Range(-range.z,range.z)
        );
    }
}
