using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;


    [Header("States")]
    [SerializeField] internal bool onGround;

    [Header("Variables")]
    [SerializeField] internal float health;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DoDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
