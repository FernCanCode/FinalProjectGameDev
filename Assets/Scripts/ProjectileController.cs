using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    [SerializeField] private float projectileSpeed;
    [SerializeField] private int damageAmount = 1;
    public Rigidbody2D r2d;
    public Vector2 direction;
    public GameObject bulletImpact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        r2d.velocity=direction*projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().DamageToEnemy(damageAmount);
        }
        Instantiate(bulletImpact, transform.position, Quaternion.identity);
        Destroy(gameObject);    
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);    
    }
}
