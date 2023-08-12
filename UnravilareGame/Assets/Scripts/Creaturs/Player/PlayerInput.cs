using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInput : MonoBehaviour
{
    public float moveDir { get; private set; }
    public Action onJump;

    public void OnMove(InputValue inputValue)
    {
        float moveInput = inputValue.Get<float>();
        moveDir = moveInput;
    }

    public void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed) onJump?.Invoke();
    }

    public void OnApplyAbility(InputValue inputValue)
    { 
       if (inputValue.Get<float>() != 0)
        {
          
        }
    }
    public void OnShowAbility(InputValue inputValue)
    {
        if ( inputValue.Get<float>() != 0 )
        {
           // _player.ShowAbbilityPanel(true);
        }
        else if (inputValue.Get<float>() == default )
        {
           // _player.ShowAbbilityPanel(false);
        }
    }

}
