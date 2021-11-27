using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;

    [Header("States")]
    [SerializeField] internal bool onGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
