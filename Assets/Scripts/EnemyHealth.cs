using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;

    public GameObject deathVFX;

    public void DamageToEnemy(int damageAmount)
    {
        maxHealth = maxHealth - damageAmount;

        if(maxHealth <= 0)
        {
            if(deathVFX != null)
            {
                Instantiate(deathVFX, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
