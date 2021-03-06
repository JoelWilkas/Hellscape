using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    //public GameObject bodyGO;

    private float time;
    private float speed;

    public MoveData moveData;

    public virtual void Start()
    {
        //bodyGO = transform.Find("body").gameObject;
        rb = GetComponent<Rigidbody2D>();
        //anim = bodyGO.GetComponent<Animator>();

        
    }

    private void FixedUpdate()
    {
        speed = moveData.movementCurve.Evaluate(time);
        time += Time.deltaTime;

        rb.velocity = new Vector2(speed * moveData.moveSpeed, rb.velocity.y);
        if (time >= moveData.movementCurve.keys[moveData.movementCurve.keys.Length - 1].time * 2) time = 0;
    }



}
