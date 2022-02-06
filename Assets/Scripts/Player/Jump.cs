using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Component")]
    private InputHandler input;
    private Player player;
    private Animator animator;

    [Header("Variables")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowFallMultiplier;


    [HideInInspector] public bool jumpRequest;
    [HideInInspector] public bool stoppedJumping;
    

    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }


    private void Awake()
    {
        input = GetComponent<InputHandler>();
    }


    private void Update()
    {
        BetterJump();
        if (animator.GetBool("Attack") == false && player.rb.velocity.y > 0.5f && !player.onGround)
        {
            animator.SetBool("Jump", true);
            
        } else if (animator.GetBool("Attack") == false && player.rb.velocity.y < -0.5f && !player.onGround)
        {
            animator.SetBool("Falling", true);
        } 
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);
        }

        if (player.onGround)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);
        }
    }

    private void FixedUpdate()
    {
        if(jumpRequest == true)
        {
            jumpRequest = false;
            DoJump();
        }

    }

    private void DoJump()
    {
        player.rb.velocity += Vector2.up * jumpForce;
        player.audioManager.Play("Jump");
    }

    private void BetterJump()
    {
        if(player.rb.velocity.y < 0)
        {
            player.rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if(player.rb.velocity.y > 0 && stoppedJumping)
        {
            player.rb.velocity += Vector2.up * Physics2D.gravity.y * (lowFallMultiplier - 1) * Time.deltaTime;
        }
    }
}
