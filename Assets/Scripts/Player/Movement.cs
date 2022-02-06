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
    private Animator anim;

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        dir = input.movement.ReadValue<Vector2>();


        targetVelocity = new Vector2(maxSpeed * dir.x, player.rb.velocity.y);

        Vector3 characterScale = transform.localScale;

        if(Mathf.Abs(player.rb.velocity.x) > 0.2)
        {
            anim.SetBool("Move", true);
        } else
        {
            anim.SetBool("Move", false);
        }

        if (dir.x > 0)
        {
            animator.Play("Right Camera");
            characterScale.x = 2f;

        }
        else if (dir.x < 0)
        {
            animator.Play("Left Camera");
            characterScale.x = -2f;
            
        }
        transform.localScale = characterScale;

        if(Mathf.Abs(player.rb.velocity.x) > 1 && !player.audioManager.IsPlaying("Walk"))
        {
            player.audioManager.Play("Walk");
        }



    }

    private void FixedUpdate()
    {
        player.rb.velocity = Vector2.SmoothDamp(player.rb.velocity, targetVelocity, ref velocity, smoothTime);
    }

}
