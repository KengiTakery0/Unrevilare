using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : Creature
{
    [SerializeField] PlayerInput playerInput;

    void OnEnable()
    {
        playerInput.onJump += Jump;
    }
    private void OnDisable()
    {
        playerInput.onJump -= Jump;
    }
    protected override void FixedUpdate()
    {
        moveDirection = playerInput.moveDir;
        base.FixedUpdate();
    }
   
}
