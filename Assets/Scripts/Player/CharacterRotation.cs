using UnityEngine;

[RequireComponent(typeof(ICustomInput))]
public class CharacterRotation : MonoBehaviour
{
    [SerializeField] Transform _characterModelTransform;
    ICustomInput _customInput;

    void Awake(){
        _customInput = GetComponent<ICustomInput>();
    }

    void Update(){
        Rotation();
    }

    void Rotation(){
        Vector3 targetDirection = new Vector3(_customInput.GetInput().x, 0, _customInput.GetInput().y);
        _characterModelTransform.LookAt(_characterModelTransform.position + targetDirection, Vector3.up);
    }

}
