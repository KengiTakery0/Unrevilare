using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    
    [SerializeField] Player _player;

    public void OnMove(InputValue inputValue)
    {
        float moveInput = inputValue.Get<float>();
        _player.SetMoveDirection(moveInput);
    }

    public void OnJump(InputValue inputValue)
    {

    }
    public void OnShowAbbility(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
           _player.isShowAbbityMenu= true;
        }
        else _player.isShowAbbityMenu = false;  
        
    }

}
