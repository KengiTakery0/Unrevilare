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
        Debug.Log(_creatureRigitBody.linearVelocity.y);
    }


    private void Jump()
    {
        if (!_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        _creatureRigitBody.AddForce(Vector2.up * _jumpStreigth, ForceMode2D.Impulse);
        _creatureAnimator.SetTrigger(isJumpingKey);
    }

    public void UseAbility(AbilityObject ability)
    {
        // Добавляем проверку на null
        if (ability == null || ability.ability == null || ability.ability.Object == null)
        {
            Debug.LogError("Ability or its components are null!");
            return;
        }
    
        // Более безопасное вычисление позиции
        Vector3 abilityOffset = new Vector3(ability.ability.distance * transform.lossyScale.x, 0, 0);
        Vector3 currentAbilityTransform = _abilityTarnsform.position + abilityOffset;
        
        GameObject g = Instantiate(ability.ability.Object, currentAbilityTransform, Quaternion.identity);
        g.transform.localScale = transform.lossyScale; // Используем lossyScale для мирового масштаба
        
        // Добавляем отладку
        Debug.Log($"Ability spawned at: {currentAbilityTransform}");
    }
}
