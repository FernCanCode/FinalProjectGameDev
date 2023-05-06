using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody2D r2d;
    public CapsuleCollider2D coll;
    public Animator anima;
    public SpriteRenderer sprite;

    private int jumpCount = 0;
    private bool onGround;
    
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private Transform onGroundPoint;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float jumpForce = 20f;

    public ProjectileController bullet;
    public Transform bulletOrigin;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        r2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed, r2d.velocity.y);

        if(r2d.velocity.x < 0f)
        {
            sprite.flipX=true;
            
        }
        else if (r2d.velocity.x > 0f)
        {
            sprite.flipX=false;
        }

         //Jumping movement
         //Check if currently on the ground
         onGround = Physics2D.OverlapCircle(onGroundPoint.position, .15f, jumpableGround);
         //Checks for jump or double jump
        if(Input.GetButtonDown("Jump") && (onGround || jumpCount<maxJumpCount))
        {
            if(onGround)
            {
                jumpCount=0;
            }
            jumpCount++;
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            
            Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
            anima.SetTrigger("fire");
        }


        anima.SetFloat("speed", Mathf.Abs (r2d.velocity.x));
        anima.SetBool("grounded", onGround);


    }

    

   
}
