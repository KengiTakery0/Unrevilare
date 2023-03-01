using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] Rigidbody2D playerRigitBody;

    private float moveDirection;

    public bool isShowAbbityMenu {  get; set; }
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
        Debug.Log(isShowAbbityMenu);
        Move();
    }

    void Move()
    {
        playerRigitBody.velocity = new Vector2(speed* moveDirection*Time.deltaTime, playerRigitBody.velocity.y);
    }
}
