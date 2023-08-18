using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : Creature, IAbilityController
{
    [SerializeField] float _jumpStreigth;

    [SerializeField] PlayerInput playerInput;
    [SerializeField] Transform _abilityTarnsform;
    [SerializeField] List<AbilityObject> _playerabilities;
    [Range(0, 3)][SerializeField] int abilityIndex;
    private static readonly int isJumpingKey = Animator.StringToHash("isJumped");

    void OnEnable()
    {
        playerInput.onJump += Jump;
        playerInput.onMove += base.Move;
        playerInput.onUseAbilty.AddListener(() => UseAbility(_playerabilities[abilityIndex]));
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
        _creatureRigitBody.AddForce(Vector2.up * _jumpStreigth, ForceMode2D.Impulse);
        _creatureAnimator.SetTrigger(isJumpingKey);
    }

    public void UseAbility(AbilityObject ability)
    {
        Vector3 curentAbilityTransform = new(_abilityTarnsform.position.x + (ability.ability.distance * transform.lossyScale.x), 
            _abilityTarnsform.position.y, _abilityTarnsform.position.z);
        
        GameObject g = Instantiate(ability.ability.Object, curentAbilityTransform, Quaternion.Euler(0, 0, 0));
        g.transform.localScale= transform.localScale;
    }
}
