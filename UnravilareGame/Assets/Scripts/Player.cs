using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject AbbilityPanel;

    [SerializeField] float speed;
    [SerializeField] float jumpStreigth;

    [SerializeField] Rigidbody2D playerRigitBody;
    [SerializeField] BoxCollider2D groungcheck;

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
        Move();
    }
    public void Jump()
    {
        if (!groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        playerRigitBody.velocity += new Vector2(playerRigitBody.velocity.x, jumpStreigth);
    }

    void Move()
    {
        playerRigitBody.velocity = new Vector2(Mathf.Pow(speed,2) * moveDirection * Time.deltaTime, playerRigitBody.velocity.y);
    }

    public void ShowAbbilityPanel(bool state)
    {
        AbbilityPanel.SetActive(state);
    }
}
