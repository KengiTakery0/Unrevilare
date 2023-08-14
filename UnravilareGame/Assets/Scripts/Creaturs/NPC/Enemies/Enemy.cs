using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] BoxCollider2D _wallCheck;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void Movement()
    {
        
    }
}
