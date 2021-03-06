using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Components")]
    private Player player;
    private InputHandler input;

    [Header("Variables")]
    [SerializeField] private float dashTime;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCooldown;
    private float currentDashTime;
    private float currentDashCooldown;

    [HideInInspector] public Vector2 dir;
    [HideInInspector] public Vector2 currentDir;

    public bool dashRequest;
    public bool canDash = false;
    private void Start()
    {
        player = GetComponent<Player>();

        currentDashTime = 0;
    }

    private void Awake()
    {
        input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        dir = input.movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        canDash = currentDashCooldown <= 0;
        currentDashCooldown -= Time.deltaTime;
        if (dashRequest)
        {
            DoDash();
        }
    }

    private void DoDash()
    {
        if (currentDashTime <= dashTime)
        {
            player.rb.velocity = new Vector2(dashForce * currentDir.x, 0);
            currentDashTime += Time.deltaTime;
        } else
        {
            dashRequest = false;
            currentDashTime = 0;
            currentDir = Vector2.zero;
            currentDashCooldown = dashCooldown;
            Debug.Log("TTT");
        }
    }
}
