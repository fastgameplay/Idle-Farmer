using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBackPack : MonoBehaviour
{
    public int Quantity{
        get{
            return _quantity;
        }
        set{
            if(value >= 0 && value <= _maxAmount){
                SetSize(value);
                _quantity = value;

            }
        }
    }
    public bool IsMax{
        get{
            return _quantity == _maxAmount;
        }
    }

    [SerializeField] BackPackScriptable _bpData;
    [SerializeField] Transform _backPackBase;
    GameObject _backPackObj;

    float _sliceHeight;
    int _maxAmount;
    int _quantity;
    void Start(){
        InitializeBackPack();


    }
    void InitializeBackPack(){
        _backPackObj = Instantiate(_bpData.Prefab, Vector3.zero, Quaternion.identity, _backPackBase);
        _backPackObj.transform.localScale = _bpData.MaxSize;
        _backPackObj.GetComponent<MeshRenderer>().material.color = _bpData.Color;
        _sliceHeight = _bpData.MaxSize.y / _bpData.MaxAmount;
        _maxAmount = _bpData.MaxAmount;
        
        Quantity = 0;
    }

    void SetSize(int size){
        if(size == 0) _backPackObj.SetActive(false);
        else if (!_backPackObj.activeSelf) _backPackObj.SetActive(true);
        _backPackObj.transform.localScale = new Vector3(_backPackObj.transform.localScale.x, _sliceHeight * size, _backPackObj.transform.localScale.z); 
        _backPackObj.transform.localPosition = new Vector3(0, _backPackObj.transform.localScale.y/2, 0);
    }
}
