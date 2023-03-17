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
                _quantity = _bpText.Amount = value;

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
    [SerializeField] StorageText _bpText;
    [SerializeField] Transform AmbarTransform;
    GameObject _backPackObj;
    Transform _flyingBlockSpawnPoint;
    float _sliceHeight;
    int _lastSize, _maxAmount, _quantity;
    void Start(){
        InitializeBackPack();


    }
    void InitializeBackPack(){

        _backPackObj = Instantiate(_bpData.Prefab, Vector3.zero, Quaternion.identity, _backPackBase);
        _backPackObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _backPackObj.transform.localScale = _bpData.MaxSize;
        _backPackObj.GetComponent<MeshRenderer>().material.color = _bpData.Color;
        _sliceHeight = _bpData.MaxSize.y / _bpData.MaxAmount;
        _maxAmount = _bpText.MaxAmount = _bpData.MaxAmount;
        
        _flyingBlockSpawnPoint = new GameObject("FlyingBlockSpawnPoint").transform;
        _flyingBlockSpawnPoint.SetParent(_backPackBase);
        
        Quantity = 0;
    }

    void SetSize(int size){
        if(size < _quantity) {
            Instantiate(_bpData.FlyingBlockPrefab).
                SetUp(
                    _flyingBlockSpawnPoint.position,
                    _flyingBlockSpawnPoint.rotation, 
                    new Vector3(_backPackObj.transform.localScale.x, _sliceHeight, _backPackObj.transform.localScale.z),
                    AmbarTransform.position
                );
        }
        if(size == 0) _backPackObj.SetActive(false);
        else if (!_backPackObj.activeSelf) _backPackObj.SetActive(true);
        _backPackObj.transform.localScale = new Vector3(_backPackObj.transform.localScale.x, _sliceHeight * size, _backPackObj.transform.localScale.z); 
        _backPackObj.transform.localPosition = new Vector3(0, _backPackObj.transform.localScale.y/2, 0);
        _flyingBlockSpawnPoint.transform.localPosition = new Vector3(0, _sliceHeight * size - _sliceHeight / 2, 0);
    }
}
