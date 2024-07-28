using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sideways : MonoBehaviour
{
    [SerializeField]private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingleft;
    private float rightedge;
    private float leftedge;
    private void Awake()
    {
        leftedge= transform.position.x- movementDistance;
        rightedge = transform.position.x + movementDistance;

    }

    private void Update()
    {
        if (movingleft)
        {
            if (transform.position.x > leftedge)
            {transform.position=new Vector3(transform.position.x-speed*Time.deltaTime,transform.position.y,transform.position.z);

            }
            else { movingleft = false; }
        }
        else
        {
            if(transform.position.x < rightedge)
            {
                
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);


                }
            else
                movingleft = true;

            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().Takedamage(damage); 
        }
    }
}
