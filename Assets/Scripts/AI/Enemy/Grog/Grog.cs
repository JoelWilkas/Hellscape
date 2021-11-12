using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grog : MonoBehaviour
{

    [SerializeField] private AiController Ai = null;
    [SerializeField] private float detectionRange;
    private GameObject target;
    private bool playerDetection;
    private void Awake()
    {
        Ai.health = 3;
        Ai.attackDamage = 1;
        Ai.canJump = false;
        Ai.detectionRange = detectionRange;
    }

    private void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, detectionRange);

        if(collider != null && collider.gameObject.tag == "Player")
        {
            target = collider.gameObject;
            playerDetection = true;
            Vector2 distance = target.transform.position - transform.position;
            Debug.Log(distance.x);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (playerDetection)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere((Vector2)transform.position, detectionRange);
        }
    }
}
