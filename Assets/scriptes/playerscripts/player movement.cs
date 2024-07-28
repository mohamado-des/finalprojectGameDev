using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask walllayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    public float speed;
    public float jumpPower;
    private float horizontalinput;
    [SerializeField] private AudioClip jumpsound;
    private Animator anim;
    private float walljumpcooldown;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();    
    }

    private void Update()

    {
         horizontalinput = Input.GetAxis("Horizontal");
       
        
        

            //flip
            if (horizontalinput > 0.01f)
                transform.localScale = Vector3.one;

        if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);




        anim.SetBool("Run", horizontalinput != 0);
        anim.SetBool("grounded",isGrounded())   ;


        if (walljumpcooldown > 0.2f) 
        {

            

            rb.velocity = new Vector2(horizontalinput * speed, rb.velocity.y);
            if(onWall()&& !isGrounded())
            {

                rb.gravityScale = 4;
                rb.velocity=Vector2.zero;
            }
            else
                rb.gravityScale= 6;
            
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
        else
            walljumpcooldown += Time.deltaTime;
    
    
    }
        private void Jump()
        {
            if (isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                anim.SetTrigger("jump");
                soundmanager.instance.playsound(jumpsound);
            }
            else if (onWall() && !isGrounded()) 
            {
            soundmanager.instance.playsound(jumpsound);
            if (horizontalinput == 0)
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-MathF.Sign(transform.localScale.x),transform.localScale.y,transform.localScale.z);

            }
            else
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 14);

            }
                walljumpcooldown = 0;
            

        }





    }
   
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider!=null; 
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, walllayer);
        return raycastHit.collider != null;
    }


    public bool canAttack() 
    {
    
    return horizontalinput==0 && isGrounded() && !onWall();
    }
}

