using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Roller>().TakeDamage(damage);

        }
    }


}
