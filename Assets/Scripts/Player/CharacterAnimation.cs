using UnityEngine;

[RequireComponent(typeof(ICustomInput))]
public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;
    ICustomInput _customInput;

    bool _runningState; 
    void Awake(){
        if(_animator == null) Debug.LogError("_animator refrence is missing!");
        _customInput = GetComponent<ICustomInput>();
        
    }

    void Update(){
        if(_customInput.IsActive() != _runningState){
            _runningState = _customInput.IsActive();
            _animator.SetBool("IsRunning", _runningState);
        }
    }
}
