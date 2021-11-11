using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    private PlayerRoot player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    [SerializeField] private float velPower;
    [SerializeField] private float frictionAmount;


    private void Start()
    {
        player = GetComponent<PlayerRoot>();
    }

    private void FixedUpdate()
    {
        Move();
        //CreateFriction();
    }

    private void Move()
    {
        float targetSpeed = player.dir.x * moveSpeed;
        float speedDif = targetSpeed - player.rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        player.rb.AddForce(movement * Vector2.right);

     

        //if(player.dir.x > 0)
        //{
        //    transform.localScale = new Vector3(-0.002520795f, transform.localScale.y, transform.localScale.z);
        //} else if(player.dir.x < 0)
        //{
        //    transform.localScale = new Vector3(0.002520795f, transform.localScale.y, transform.localScale.z);
        //}


        //player.rb.velocity = new Vector2(velocity * player.dir.x, player.rb.velocity.y);

    }

    //private void CreateFriction()
    //{
    //    if (player.isGrounded)
    //    {
    //        float amount = Mathf.Min(Mathf.Abs(player.rb.velocity.x), Mathf.Abs(frictionAmount));
    //        amount *= Mathf.Sign(player.rb.velocity.x);
    //        player.rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
    //    }
    //}
}
