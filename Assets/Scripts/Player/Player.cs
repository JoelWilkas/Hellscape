using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    [SerializeField] internal AudioManager audioManager;


    [Header("States")]
    [SerializeField] internal bool onGround;
    [SerializeField] internal bool canTakeDamage = true;
    [SerializeField] internal bool isAttacking;

    [Header("Variables")]
    [SerializeField] internal float health;


    [Header("IFrames")]
    [SerializeField] private Color flashColor;
    [SerializeField] private Color RegularColor;
    [SerializeField] private float flashDuration;
    [SerializeField] private int numOfFlashes;
    [SerializeField] Collider2D triggerCollider;
    [SerializeField] private SpriteRenderer playerSprite;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DoDamage(float damage, float dir)
    {

        if (!canTakeDamage)
        rb.AddForce(new Vector2(300 * dir, 100));
        health -= damage;
        StartCoroutine(FlashColor());
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

    private IEnumerator FlashColor()
    {
        print("Hit!");
        int temp = 0;
        canTakeDamage = false;
        while(temp < numOfFlashes)
        {
            playerSprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            playerSprite.color = RegularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }

        canTakeDamage = true;
    }

}
