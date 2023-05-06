using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healAmount=3;

    public GameObject healEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            PlayerHealth.instance.PlayerHeal(healAmount);

            if(healEffect != null)
            {
                Instantiate(healEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
