using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject AbilityPanel;

    [Header("NumericVaues")]
    [SerializeField] float speed;
    [SerializeField] float jumpStreigth;
    [SerializeField] Transform abililtyOrigin;

    [Header("Phisics")]
    [SerializeField] Rigidbody2D playerRigitBody;
    [SerializeField] BoxCollider2D groungcheck;

    [Header("Animation")]
    [SerializeField] Animator playerAnimator;

    [Header("Abilities")]
   
    [SerializeField] AbilitiesController _abilitiesController;
   

    public int currentAbbilityIndex;

    private float moveDirection;
    public float HorizontalLook { get; private set; } 
    private void Start()
    {
        
    }

    public void UseShieldAbility()
    {
        Instantiate(_abilitiesController.GetShieldProjectile(), transform.position, transform.rotation);
    }

    public void UseAtackAbility()
    {
        Instantiate(_abilitiesController.GetAtackProjectile(),transform.position,transform.rotation);
    }

    void Update()
    {
        isFalling();
        FlipPlayerSprite();
        Move();
        HorizontalLook = transform.localScale.x;
    }
    public void Jump()
    {
        if (!groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        playerRigitBody.velocity += new Vector2(playerRigitBody.velocity.x, jumpStreigth);
        playerAnimator.SetTrigger("isJumped");
    }

    void Move()
    {
        playerRigitBody.velocity = new Vector2(Mathf.Pow(speed, 2) * moveDirection * Time.deltaTime, playerRigitBody.velocity.y);
        bool hasHorizontalMove = Mathf.Abs(playerRigitBody.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", hasHorizontalMove);
    }

    void isFalling()
    {
        if (playerRigitBody.velocity.y < 0 && !groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            playerAnimator.SetTrigger("isFalling");
        }
    }

    void FlipPlayerSprite()
    {
        bool hasHorizontalMove = Mathf.Abs(playerRigitBody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalMove)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigitBody.velocity.x), 1f);
        }
    }

    public void ShowAbbilityPanel(bool state)
    {
        AbilityPanel.SetActive(state);
    }
    public void SetMoveDirection(float direction)
    {
        moveDirection = direction;
    }
}
