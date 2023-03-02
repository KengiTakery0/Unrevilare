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

    public void OnApplyAbility(InputValue inputValue)
    { 
       if (inputValue.Get<float>() != 0)
        {
           switch(_player.currentAbbilityIndex)
            {
                case 0: _player.UseAtackAbility(); break;
                case 1: _player.UseShieldAbility(); break;
            }
        }
    }
    public void OnShowAbility(InputValue inputValue)
    {
        if ( inputValue.Get<float>() != 0 )
        {
            _player.ShowAbbilityPanel(true);
        }
        else if (inputValue.Get<float>() == default )
        {
            _player.ShowAbbilityPanel(false);
        }
    }

}
