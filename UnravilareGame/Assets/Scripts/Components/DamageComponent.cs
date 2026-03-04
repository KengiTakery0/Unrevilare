using UnityEngine;
using UnityEngine.Events;

public class DamageComponent : MonoBehaviour
{
    [SerializeField]
    float Damage;

   
    public void DealDamage(GameObject hp)
    {
        hp.GetComponent<HelthComponent>().TakeDamage(Damage);
    }

}
