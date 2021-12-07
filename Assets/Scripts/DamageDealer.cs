using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float damageDealing;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.DoDamage(damageDealing);
    }
}
