using UnityEngine;

public class AdvancedSwimming : MonoBehaviour
{
    [Header("Swimming Parameters")]
    public float swimForce = 8f;
    public float maxSwimSpeed = 4f;
    public float waterDensity = 0.5f;
    
    [Header("Buoyancy")]
    public float buoyancyForce = 3f;
    public float surfacePushForce = 2f;
    
    private Rigidbody2D rb;
    private bool isInWater = false;
    private float originalGravity;
    private float originalLinearDamping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
        originalLinearDamping = rb.linearDamping; 
    }

    void Update()
    {
        if (isInWater)
        {
            HandleSwimming();
        }
    }

    void HandleSwimming()
    {
        float verticalInput = Input.GetAxis("Vertical");
        
        if (Mathf.Abs(verticalInput) > 0.1f)
        {
            Vector2 swimDirection = verticalInput > 0 ? Vector2.up : Vector2.down;
            rb.AddForce(swimDirection * swimForce * Mathf.Abs(verticalInput));
        }
        
        Vector2 velocity = rb.linearVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -maxSwimSpeed, maxSwimSpeed);
        rb.linearVelocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterTrigger"))
        {
            EnterWater();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WaterTrigger"))
        {
            ExitWater();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("WaterTrigger"))
        {
            rb.AddForce(Vector2.up * buoyancyForce);
        }
    }

    void EnterWater()
    {
        isInWater = true;
        rb.gravityScale = originalGravity * waterDensity;
        rb.linearDamping = originalLinearDamping * 2f;
        
        Debug.Log("Вошел в воду");
    }

    void ExitWater()
    {
        isInWater = false;
        rb.gravityScale = originalGravity;
        rb.linearDamping = originalLinearDamping;
        
        Debug.Log("Вышел из воды");
    }
}