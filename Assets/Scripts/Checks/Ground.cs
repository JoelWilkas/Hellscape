using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [Header("Components")]
    private Player player;


    [Header("Variables")]
    [SerializeField] private float rayCastLength;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        player.onGround = Physics2D.Raycast(transform.position, Vector2.down, rayCastLength, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayCastLength);
    }

}
