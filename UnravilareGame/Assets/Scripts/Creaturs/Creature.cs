using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Creature : MonoBehaviour
{

    [Header("Phisics")]
    [SerializeField] protected Rigidbody2D _creatureRigitBody;
    [SerializeField] protected BoxCollider2D _groungcheck;



    [Header("Animation")]
    [SerializeField] protected Animator _creatureAnimator;

    [Header("Stats")]
    [SerializeField] float _movingspeed;


    private static readonly int isFallingKey = Animator.StringToHash("isFalling");
    private static readonly int isMovingKey = Animator.StringToHash("isMoving");
   

    public float moveDirection { get; set; }

    bool hasHorizontalMove;

    protected virtual void FixedUpdate()
    {
        isFalling();
    }


    private void isFalling()
    {
        if (_creatureRigitBody.velocity.y < 0f && !_groungcheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _creatureAnimator.SetTrigger(isFallingKey);
        }
    }
    protected virtual void Move(float moveDir)
    {
        _creatureRigitBody.velocity = new Vector2(Mathf.Pow(_movingspeed, 2) * moveDir, _creatureRigitBody.velocity.y);
         hasHorizontalMove = Mathf.Abs(_creatureRigitBody.velocity.x) > Mathf.Epsilon;
        _creatureAnimator.SetBool(isMovingKey, hasHorizontalMove);
        FlipCreatureSprite();
    }




    void FlipCreatureSprite()
    {
        if (hasHorizontalMove)
        {
            transform.localScale = new Vector2(Mathf.Sign(_creatureRigitBody.velocity.x), 1f);
        }
    }
}

