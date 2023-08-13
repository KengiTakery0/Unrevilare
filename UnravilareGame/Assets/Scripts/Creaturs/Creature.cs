using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Creature : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float _runningspeed;
    [SerializeField] float _jumpStreigth;

    [Header("Phisics")]
    [SerializeField] Rigidbody2D _playerRigitBody;
    [SerializeField] BoxCollider2D _groungcheck;
  



    [Header("Animation")]
    [SerializeField] Animator _playerAnimator;

    private static readonly int isRunningKey = Animator.StringToHash("isRunning");
    private static readonly int isJumpingKey = Animator.StringToHash("isJumped");
    private static readonly int isFallingKey = Animator.StringToHash("isFalling");

    public float moveDirection { get; set; }

  

    protected virtual void FixedUpdate()
    {
        isFalling();
        Move();
        FlipPlayerSprite();
    }

    void Move()
    {
        _playerRigitBody.velocity = new Vector2(Mathf.Pow(_runningspeed, 2) * moveDirection, _playerRigitBody.velocity.y);
        bool hasHorizontalMove = Mathf.Abs(_playerRigitBody.velocity.x) > Mathf.Epsilon;
        _playerAnimator.SetBool(isRunningKey, hasHorizontalMove);
    }
    protected virtual void Jump()
    {
        if (!_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        _playerRigitBody.velocity += new Vector2(_playerRigitBody.velocity.x, _jumpStreigth);
        _playerAnimator.SetTrigger(isJumpingKey);
    }
    void isFalling()
    {
        if (_playerRigitBody.velocity.y < 0 && !_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _playerAnimator.SetTrigger(isFallingKey);
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

