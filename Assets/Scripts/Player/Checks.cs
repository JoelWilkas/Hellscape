using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checks : MonoBehaviour
{
    private PlayerRoot player;
    [SerializeField] private float groundRayCastLength;
    [SerializeField] private LayerMask groundLayerMask;

    private void Start()
    {
        player = GetComponent<PlayerRoot>();
    }

    private void FixedUpdate()
    {
        player.isGrounded = IsGrounded();
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundRayCastLength, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRayCastLength);

    }



}
