using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpp : MonoBehaviour
{
    private PlayerRoot player;
    [SerializeField] private float jumpForce;
    private bool jumpRequest;


    private void Start()
    {
        player = GetComponent<PlayerRoot>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if(player.isGrounded && jumpRequest){
            player.rb.velocity = Vector2.up * jumpForce;
            jumpRequest = false;
        }
    }
}
