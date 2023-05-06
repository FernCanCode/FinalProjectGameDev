using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform[] waypoints;
    private int currentWaypoint;
    public float moveSpeed;
    public float waitTime;
    private float waitTimeCounter;
    public float jumpForce;
    
    public Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        waitTimeCounter = waitTime;

        foreach(Transform wPoint in waypoints)
        {
            wPoint.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x - waypoints[currentWaypoint].position.x) > .1f)
        {
            if(transform.position.x < waypoints[currentWaypoint].position.x)
            {
                r2d.velocity = new Vector2(moveSpeed, r2d.velocity.y);
                transform.localScale= Vector3.one;
            }
            else
            {
                
                r2d.velocity = new Vector2(-moveSpeed, r2d.velocity.y);
                transform.localScale = new Vector3(-1f,1f,1f);
            }

            if(transform.position.y < waypoints[currentWaypoint].position.y - .7f && r2d.velocity.y < .1f)
            {
                r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
            }
        }
        else
        {
            r2d.velocity=new Vector2(0f, r2d.velocity.y);

            waitTimeCounter -= Time.deltaTime;
            if(waitTimeCounter <= 0)
            {
                waitTimeCounter = waitTime;
                currentWaypoint += 1;

                if(currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint=0;
                }
            }
        }
    }
}
