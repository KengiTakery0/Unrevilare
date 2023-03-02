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
        if(inputValue.isPressed) _player.Jump();
    }
    public void OnShowAbbility(InputValue context)
    {
        if ( context.Get<float>() != 0 )
        {
            _player.ShowAbbilityPanel(true);
        }
        else if (context.Get<float>() == default )
        {
            _player.ShowAbbilityPanel(false);
        }
    }

}
