using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Creature : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float _runningspeed;
    [SerializeField] float _jumpStreigth;
    [SerializeField] float _helth;

    [Header("Phisics")]
    [SerializeField] Rigidbody2D _playerRigitBody;
    [SerializeField] BoxCollider2D _groungcheck;
    [SerializeField] PlayerInput playerInput;



    [Header("Animation")]
    [SerializeField] Animator _playerAnimator;

    private float moveDirection;

    void OnEnable()
    {
        playerInput.onJump += Jump;
    }
    private void OnDisable()
    {
        playerInput.onJump -= Jump;
    }

    protected virtual void FixedUpdate()
    {
        isFalling();
        Move();
        FlipPlayerSprite();
    }

    void Move()
    {
        moveDirection = playerInput.moveDir;
        _playerRigitBody.velocity = new Vector2(Mathf.Pow(_runningspeed, 2) * moveDirection, _playerRigitBody.velocity.y);
        bool hasHorizontalMove = Mathf.Abs(_playerRigitBody.velocity.x) > Mathf.Epsilon;
        _playerAnimator.SetBool("isRunning", hasHorizontalMove);
    }
    protected virtual void Jump()
    {
        if (!_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        _playerRigitBody.velocity += new Vector2(_playerRigitBody.velocity.x, _jumpStreigth);
        _playerAnimator.SetTrigger("isJumped");
    }
    void isFalling()
    {
        if (_playerRigitBody.velocity.y < 0 && !_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _playerAnimator.SetTrigger("isFalling");
        }
    }

    void FlipPlayerSprite()
    {
        bool hasHorizontalMove = Mathf.Abs(_playerRigitBody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalMove)
        {
            transform.localScale = new Vector2(Mathf.Sign(_playerRigitBody.velocity.x), 1f);
        }
    }
}

