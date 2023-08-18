using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public float moveDir { get; private set; }
    public Action onJump;
    public Action<float> onMove;
    public UnityEvent onUseAbilty;

    public void OnMove(InputValue inputValue)
    {
        float moveInput = inputValue.Get<float>();
        onMove?.Invoke(moveInput);
    }

    public void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed) onJump?.Invoke();
    }

    public void OnApplyAbility(InputValue inputValue)
    {
       if (inputValue.isPressed) onUseAbilty?.Invoke();
    }
    public void OnShowAbility(InputValue inputValue)
    {
        if (inputValue.Get<float>() != 0)
        {
            // _player.ShowAbbilityPanel(true);
        }
        else if (inputValue.Get<float>() == default)
        {
            // _player.ShowAbbilityPanel(false);
        }
    }

}
