using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damageAmount =1;
    // Start is called before the first frame update
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            DealDamage();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Player")
        {
            DealDamage();
        }
    }

    void DealDamage()
    {
        PlayerHealth.instance.DamageToPlayer(damageAmount);
    }
}
