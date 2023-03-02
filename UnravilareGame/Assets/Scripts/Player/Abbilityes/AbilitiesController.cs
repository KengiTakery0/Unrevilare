using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesController : MonoBehaviour
{
    #region ATACK_ABILITY
  
    [Header("AtackAbilitie")]
    [SerializeField] float _atackMovingSpeed;
    [SerializeField] float _atackMovingRange;
    [SerializeField] float _atackDamage;
    [SerializeField] GameObject _atackProjectile;
    public float GetAtackMovingSpeed() { return _atackMovingSpeed; }
    public float GetAtackMovingRange() { return _atackMovingRange; }
    public float GetAtackDamage() { return _atackDamage; }
    public GameObject GetAtackProjectile() { return _atackProjectile; }
    

    #endregion
    [Space]
    #region SHIELD_ABILITY
    [Header("ShieldAbilitie")]
    [SerializeField] float _shieldMovingSpeed;
    [SerializeField] float _shieldMovingRange;
    [SerializeField] float _shieldStreight;
    [SerializeField] float _shieldStandTime;
    [SerializeField] GameObject _shieldProjectile;
    public float GetShieldMovingSpeed() { return _shieldMovingSpeed; }
    public float GetShieldMovingRange() { return _shieldMovingRange; }
    public float GetShieldStreight() { return _shieldStreight; }
    public float GetShieldStandTime() { return _shieldStandTime; }
    public GameObject GetShieldProjectile() { return _shieldProjectile; }
  
    #endregion
    [Space]
    #region HEAL_ABILITY
    [Header("HealAbilitie")]
    [SerializeField] float _healMovingSpeed;
    [SerializeField] float _healMovingRange;
    [SerializeField] float _healStreight;
    [SerializeField] float _healRange;
    [SerializeField] float _healStandTime;
    [SerializeField] GameObject _healProjectile;
    public float GetHealMovingSpeed() { return _healMovingSpeed; }
    public float GetHealMovingRange() { return _healMovingRange; }
    public float GetHealStreight() { return _healStreight; }
    public float GetHealStandTime() { return _healStandTime; }
    public float GetHealRange() { return _healRange; }
    public GameObject GetHealProjectile() { return _healProjectile; }
    #endregion
    [Space]
    #region SHADOW_ABILITY
    [Header("ShadowAbilitie")]
    [SerializeField] float _shadowMovingSpeed;
    [SerializeField] float _shadowMovingRange;
    [SerializeField] float _shadowStandTime;
    [SerializeField] GameObject _shadowProjectile;
    public float GetShadowMovingSpeed() { return _shadowMovingSpeed; }
    public float GetShadowMovingRange() { return _shadowMovingRange; }
    public float GetShadowStandTime() { return _shadowStandTime; }
    public GameObject GetShadowProjectile() { return _shadowProjectile; }
    #endregion

  
}
