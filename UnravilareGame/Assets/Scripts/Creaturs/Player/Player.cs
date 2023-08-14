using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : Creature
{
    [SerializeField] float _jumpStreigth;

    [SerializeField] PlayerInput playerInput;
    [SerializeField] protected BoxCollider2D _groungcheck;

    private static readonly int isJumpingKey = Animator.StringToHash("isJumped");
    private static readonly int isFallingKey = Animator.StringToHash("isFalling");


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
        base.FixedUpdate();
        moveDirection = playerInput.moveDir;
        isFalling();
    }
    private void isFalling()
    {
        if (_creatureRigitBody.velocity.y < 0f && _groungcheck.IsTouchingLayers(LayerMask.NameToLayer("Ground")))
        {
            _creatureAnimator.SetTrigger(isFallingKey);
        }
    }

    private void Jump()
    {
        if (!_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        _creatureRigitBody.velocity += new Vector2(_creatureRigitBody.velocity.x, _jumpStreigth);
        _creatureAnimator.SetTrigger(isJumpingKey);
    }

}
