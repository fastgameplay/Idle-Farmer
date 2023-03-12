using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHolder : MonoBehaviour
{
    public bool IsGrown{get{return _progress >= 1;}}

    GameObject _plant;

    Vector3 _startPos;
    Vector3 _endPos;

    float _progress;
    float _growthTime;

    float elapsedTime;

    bool _isGrowing;

    void Awake(){
        _isGrowing = false;
    }

    void Update(){
        if(_isGrowing){
            if(_progress < 1){
                elapsedTime += Time.deltaTime;
                _progress = elapsedTime / _growthTime;
                _plant.transform.localPosition = Vector3.Lerp(_startPos, _endPos, _progress);

            }

        }
    }

    public void InstantiateCrop(PlantScriptable plantData){
        _plant = Instantiate(plantData.Prefab, Vector3.zero, Quaternion.identity, transform);
        

        _plant.transform.localPosition = _startPos = new Vector3(0, plantData.GrowthRange.x, 0);
        _endPos   = new Vector3(0, plantData.GrowthRange.y, 0);

        _growthTime = plantData.GrowthTime;

        _isGrowing = true;

    }
    
    public void Chop(){
        elapsedTime = _progress = 0;
        
    }

}
