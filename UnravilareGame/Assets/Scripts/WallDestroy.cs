using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    [SerializeField] GameObject sprite;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(sprite);
        }
    }
}
