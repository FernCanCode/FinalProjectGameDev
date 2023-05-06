using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizardController : MonoBehaviour
{
    [SerializeField] private float aggroRange=5f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnRate;

    private bool chasing=false;
    
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerHealth.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!chasing)
        {
            if(Vector3.Distance(transform.position, player.position) < aggroRange)
            {
                chasing=true;
            }
        }
        else
        {
            if(player.gameObject.activeSelf)
            {
                Vector3 direction = transform.position - player.position;
                //Get angle in radians, then change to degrees
                float rotateAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                Quaternion targetAngle = Quaternion.AngleAxis(rotateAngle, Vector3.forward);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, turnRate*Time.deltaTime);
                transform.position += -transform.right * moveSpeed * Time.deltaTime;

                    
            }
        }
        
        
    }
}
