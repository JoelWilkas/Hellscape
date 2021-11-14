using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newJump : MonoBehaviour
{
    private PlayerRoot player;

    public float accelerationMultiplier = 2.5f;
    public float maxAcceleration = 2.0f;
    public float jumpForce = 350.0f;
    public float airDrag = 0.8f;


    private void Start()
    {
        player = GetComponent<PlayerRoot>();
    }


    private void DoJump()
    {
        if(player.isGrounded && Input.GetButtonDown("Jump"))
        {
            StartJump();
            Debug.Log("Tesst");
        }

        if (!player.isGrounded && !Input.GetButtonDown("Jump") && player.rb.velocity.y > 0.01f)
        {
            CancelJump();
        }
    }





    private void StartJump()
    {
        player.rb.AddForce(new Vector2(0, jumpForce * Time.deltaTime));
        Debug.Log("Yes");
    }


    private void CancelJump()
    {
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.rb.velocity.y * 0.72f);
        Debug.Log("NO");
    }



}