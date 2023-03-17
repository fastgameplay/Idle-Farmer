using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBlock : MonoBehaviour
{
    [SerializeField] float _speed;

    Vector3 _targetPosition;
    bool _isActive;
    void Update(){
        if(_isActive){
            transform.position = Vector3.MoveTowards(transform.position,_targetPosition, _speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, _targetPosition) < 0.01f){
                Destroy(gameObject);
            }
        }
    }
    public void SetUp(Vector3 position, Quaternion rotation, Vector3 scale, Vector3 target){
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
        _targetPosition = target;
        _isActive = true;
    }
}
