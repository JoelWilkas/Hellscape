using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    public PlayerInput input { get; private set; }

    private Player player;

    public InputAction movement;

    public InputAction jump;

    public InputAction dash;


    private Jump jumpScript;
    private Dash dashScript;
    

    public Vector2 dir { get; private set; }

    private void Awake()
    {
        player = GetComponent<Player>();
        input = new PlayerInput();
        jumpScript = GetComponent<Jump>();
        dashScript = GetComponent<Dash>();
    }

    private void OnEnable()
    {

        //Movement
        movement = input.Movement.Horizontal;

        //Jump
        jump = input.Movement.Jump;


        jump.performed += DoJump;

        jump.started += _ =>
        {
            jumpScript.stoppedJumping = false;
        };

        jump.canceled += _ =>
        {
            jumpScript.stoppedJumping = true;
        };

        //Dash
        dash = input.Movement.Dash;

        dash.performed += DoDash;


        jump.Enable();
        dash.Enable();



        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        jump.Disable();
        dash.Disable();
    }

    public void DoJump(InputAction.CallbackContext ctx)
    {
        if(player.onGround) jumpScript.jumpRequest = true;
        //Debug.Log(ctx);
    }

    public void DoDash(InputAction.CallbackContext ctx)
    {
        if (dashScript.canDash && dashScript.dir.x != 0)
        {
            dashScript.currentDir = dashScript.dir;
            dashScript.dashRequest = true;
        }
    }
}
