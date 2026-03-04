using UnityEngine;
using UnityEngine.Events;

public class TriggerStayComponent : MonoBehaviour
{
    [SerializeField] UnityEvent<GameObject> _action;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _action?.Invoke(collision.gameObject);
    }
}
