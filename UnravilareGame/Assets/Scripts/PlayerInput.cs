using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    
    [SerializeField] Player _player;

    private void OnMove(InputAction inputAction)
    {
       float moveInput = inputAction.ReadValue<float>();
        _player.SetMoveDirection(moveInput);
    }

}
