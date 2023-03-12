using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField] FieldScriptable _fieldData;


    void Start(){
        Vector3 startPos = _fieldData.StartPos; 
        for (int x = 0; x < _fieldData.MapSize.x; x++){
            for (int y = 0; y < _fieldData.MapSize.y; y++){

                FieldCell tmpCell = Instantiate(_fieldData.CellPrefab, Vector2.zero,Quaternion.identity,transform);

                tmpCell.transform.localPosition = startPos + _fieldData.GetPosition(x,y);

                tmpCell.SetUp(_fieldData.PlantData, _fieldData.PickUpPrefab);
            }
        }
    }
    
}
