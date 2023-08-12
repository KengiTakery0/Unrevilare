using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAbility : MonoBehaviour
{
    [SerializeField] AbilitiesController abilitiesController;
    Rigidbody2D rb;
    Player player;
    float HorizontalSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();

        //HorizontalSpeed= abilitiesController.GetAtackMovingSpeed() * player.HorizontalLook;
        transform.localScale = player.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x >= abilitiesController.GetAtackMovingRange()) || (transform.position.x <= -abilitiesController.GetAtackMovingRange())) Destroy(gameObject);
        Atack();
    }
    public void Atack()
    {
       rb.velocity += new Vector2(HorizontalSpeed * Time.deltaTime, rb.velocity.y);
    }

}
