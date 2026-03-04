using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HelthComponent : MonoBehaviour
{
    [SerializeField] float Health;

    [SerializeField] UnityEvent DeathAction;
    public void ModifyHealth(float health)
    {
        Health += health;
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
            Death();
    }
    private void Death()
    {
       
        DeathAction?.Invoke();
    }
}
