using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] Rigidbody2D playerRigitBody;

    private float moveDirection;

    public void SetMoveDirection(float direction)
    {
        moveDirection = direction;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moveDirection);
    }
}
