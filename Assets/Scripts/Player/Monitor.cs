using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    private PlayerRoot player;

    [SerializeField] private Vector2 velocity;
    [SerializeField] private bool onGround;
    [SerializeField] private Vector2 dir;

    private void Start()
    {
        player = GetComponent<PlayerRoot>();
    }

    private void FixedUpdate()
    {
        velocity = player.rb.velocity;
        onGround = player.isGrounded;
        dir = player.dir;
    }
}
