using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    [SerializeField] public EnemyStats enemyStats;
    [SerializeField] private StateMachine stateMachine;

    [SerializeField] private AttackState attackState;
    [SerializeField] private IdleState idleState;
    [SerializeField] private Transform targetTransform;

    [SerializeField] private float knockBack;
    private Rigidbody2D rb;


    [Header("IFrames")]
    [SerializeField] private Color flashColor;
    [SerializeField] private Color RegularColor;
    [SerializeField] private float flashDuration;
    [SerializeField] private int numOfFlashes;
    [SerializeField] Collider2D triggerCollider;
    [SerializeField] private SpriteRenderer playerSprite;
    private bool canTakeDamage;

    public float degreesPerSec = 360f;
    public float dealDamage = 1f;
    private float rollSpeed;

    
    private float time;
    private float dir;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        enemyStats.health = 5f;
    }
    public void Update()
    {
        if(enemyStats.health <= 0)
        {
            Destroy(gameObject);
        }
        if (stateMachine.currentState == attackState)
        {
            Attack();
        }

        dir = Mathf.Sign(targetTransform.position.x - transform.position.x);
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        rollSpeed = enemyStats.movementCurve.Evaluate(time);
    }


    private void Attack()
    {
        float rotAmount = degreesPerSec * rollSpeed * Time.deltaTime * dir;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));


        if(Mathf.Abs(rb.velocity.x) < enemyStats.moveSpeed)
        {
            rb.AddForce(new Vector2(rollSpeed * dir * 1, 0));   
        }
    }


    public void TakeDamage(float damage)
    {
        StartCoroutine(FlashColor());
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(knockBack * -dir, 100));
        enemyStats.health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            other.gameObject.GetComponent<Player>().DoDamage(dealDamage, dir);
        }
    }

    private IEnumerator FlashColor()
    {
        int temp = 0;
        canTakeDamage = false;
        while (temp < numOfFlashes)
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
