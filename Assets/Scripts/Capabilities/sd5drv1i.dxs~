using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField] private float maxSpeed = 4f;
    [SerializeField] private float maxAcceleration = 35f;
    [SerializeField] private float maxAirAcceleration = 20f;

    private Vector2 dir;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private Ground ground;

    private float MaxSpeedChange;
    private float acceleration;
    private bool onGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
    }

    private void Update()
    {
        dir.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(dir.x, 0f) * Mathf.Max(maxSpeed - ground.getFriction(), 0f);
    }

    private void FixedUpdate()
    {
        onGround = ground.getOnGround();
        velocity = rb.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        MaxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, MaxSpeedChange);
        rb.velocity = velocity;
    }
}
