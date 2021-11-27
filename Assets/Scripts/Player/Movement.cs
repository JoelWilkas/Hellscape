using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [Header("Components")]
    private Player player;
    private InputHandler input;
    [SerializeField] private Animator animator;


    [SerializeField] private float smoothTime;
    [SerializeField] private float maxSpeed;
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;
    private Vector2 targetVelocity = Vector2.zero;
    private Vector2 dir;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Awake()
    {
        input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        dir = input.movement.ReadValue<Vector2>();


        targetVelocity = new Vector2(maxSpeed * dir.x, player.rb.velocity.y);

        

        if (dir.x > 0)
        {
            animator.Play("Right Camera");
        }
        else if (dir.x < 0)
        {
            animator.Play("Left Camera");
        }




    }

    private void FixedUpdate()
    {
        player.rb.velocity = Vector2.SmoothDamp(player.rb.velocity, targetVelocity, ref velocity, smoothTime);
    }

}
