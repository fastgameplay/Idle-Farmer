using UnityEngine;

[RequireComponent(typeof(ICustomInput))]
public class CharacterMovement : MonoBehaviour{
    [SerializeField] float _speed;
    ICustomInput _customInput;

    void Awake(){
        _customInput = GetComponent<ICustomInput>();
    }

    void Update(){
        Movement();
    }

    void Movement(){
        Vector3 direction = Vector3.forward * _customInput.GetInput().y + Vector3.right *  _customInput.GetInput().x;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
    
}
