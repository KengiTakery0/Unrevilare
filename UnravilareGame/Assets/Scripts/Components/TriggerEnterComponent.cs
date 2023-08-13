using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterComponent : MonoBehaviour
{
    [SerializeField] UnityEvent _action;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _action?.Invoke();
    }
}
