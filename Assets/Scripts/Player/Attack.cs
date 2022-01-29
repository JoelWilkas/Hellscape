using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float coolDownTime;
    public float currentCoolDownTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentCoolDownTime <= 0)
        {
            anim.SetBool("Attack", true);
            currentCoolDownTime = coolDownTime;
        }



        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            anim.SetBool("Attack", false);
        }
    }

    private void FixedUpdate()
    {
        if (currentCoolDownTime > 0)
        {
            currentCoolDownTime -= Time.deltaTime;
        }
    }
}
