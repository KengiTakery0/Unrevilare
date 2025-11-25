using UnityEngine;

public class RotatableObject : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private string targetTag;
    [SerializeField] private float rotationSpeed = 90;
    
    private GameObject[] targetObjects;
    private bool isActive = false;

    void Awake()
    {
        FindTargetObjects();
    }

    private void FindTargetObjects()
    {
        if (!string.IsNullOrEmpty(targetTag))
        {
            targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
            Debug.Log($"Found {targetObjects.Length} objects with tag '{targetTag}'");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        isActive = !isActive;
    }

    void Update()
    {
        if (isActive && targetObjects != null)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            Vector3 rotation = new Vector3(0, 0, rotationThisFrame);
            
            foreach (GameObject target in targetObjects)
            {
                if (target != null)
                {
                    target.transform.eulerAngles += rotation;
                }
            }
        }
    }
}