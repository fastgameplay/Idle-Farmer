using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ICustomInput{
    [SerializeField] Joystick _joyStick;


    public Vector2 GetInput(){
        return _joyStick.Direction;
    }
    public bool IsActive(){
        if(_joyStick.Direction == Vector2.zero) return false;
        return true;
    }
}
