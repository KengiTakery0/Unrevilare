using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Creature : MonoBehaviour
{

    [Header("Phisics")]
    [SerializeField] protected Rigidbody2D _creatureRigitBody;
   




    [Header("Animation")]
    [SerializeField] protected Animator _creatureAnimator;

    [Header("Stats")]
    [SerializeField] float _movingspeed;


    private static readonly int isMovingKey = Animator.StringToHash("isMoving");
   

    public float moveDirection { get; set; }



    protected virtual void FixedUpdate()
    {
        Move();
        FlipCreatureSprite();
    }

    void Move()
    {
        _creatureRigitBody.velocity = new Vector2(Mathf.Pow(_movingspeed, 2) * moveDirection, _creatureRigitBody.velocity.y);
        bool hasHorizontalMove = Mathf.Abs(_creatureRigitBody.velocity.x) > Mathf.Epsilon;
        _creatureAnimator.SetBool(isMovingKey, hasHorizontalMove);
    }




    void FlipCreatureSprite()
    {
        bool hasHorizontalMove = Mathf.Abs(_creatureRigitBody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalMove)
        {
            transform.localScale = new Vector2(Mathf.Sign(_creatureRigitBody.velocity.x), 1f);
        }
    }
}

