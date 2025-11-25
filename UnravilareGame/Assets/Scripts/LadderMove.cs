using UnityEngine;

public class LadderMove : MonoBehaviour
{
    [SerializeField] float ClimbingSpeed = 4;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            float currentXVelocity = playerRb.linearVelocity.x;
            
            if (Input.GetKey(KeyCode.W))
            {
                playerRb.linearVelocity = new Vector2(currentXVelocity, ClimbingSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                playerRb.linearVelocity = new Vector2(currentXVelocity, -ClimbingSpeed);
            }
            else 
            {
                playerRb.linearVelocity = new Vector2(currentXVelocity, 0); 
            }  
        }                           
    }
}
