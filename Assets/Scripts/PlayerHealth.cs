using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;



    [SerializeField] private int maxHealth;
    public int currHealth;

    private void Awake() 
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currHealth=maxHealth;

        UIControl.instance.HealthUpdater(currHealth, maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageToPlayer(int damageAmount)
    {
        currHealth = currHealth - damageAmount;
        if(currHealth <= 0)
        {
            currHealth=0;
            RespawnControl.instance.Respawn();
        }
        UIControl.instance.HealthUpdater(currHealth, maxHealth);
    }
    public void FillHealth()
    {
        currHealth=maxHealth;
        UIControl.instance.HealthUpdater(currHealth, maxHealth);

    }

    public void PlayerHeal(int healAmount)
    {
        currHealth += healAmount;
        if(currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }

        UIControl.instance.HealthUpdater(currHealth, maxHealth);
    }
}
