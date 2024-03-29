using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FieldCell))]
[RequireComponent(typeof(Collider))]
public class CellColision : MonoBehaviour
{
    FieldCell _fieldCell;
    void Awake(){
        _fieldCell = GetComponent<FieldCell>();
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Chopper")){
            _fieldCell.Chop();
        }
    }

}
