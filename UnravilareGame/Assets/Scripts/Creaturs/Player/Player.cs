using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : Creature, IAbilityController
{
    [SerializeField] float _jumpStreigth;

    [SerializeField] PlayerInput playerInput;
    [SerializeField] List<AbilityObject> _playerabilities;

    private static readonly int isJumpingKey = Animator.StringToHash("isJumped");

    void OnEnable()
    {
        playerInput.onJump += Jump;
        playerInput.onMove += base.Move;
    }
    private void OnDisable()
    {
        playerInput.onJump -= Jump;
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        moveDirection = playerInput.moveDir;
        Debug.Log(_creatureRigitBody.velocity.y);
    }
    

    private void Jump()
    {
        if (!_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        _creatureRigitBody.AddForce(Vector2.up* _jumpStreigth,ForceMode2D.Impulse);
        _creatureAnimator.SetTrigger(isJumpingKey);
    }

    public void UseAbility(AbilityObject ability)
    {
       
    }
}
