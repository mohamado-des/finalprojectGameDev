using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class spikehead : enemydamage
{
    private Vector3 destination;
    private Vector3[] directions=new Vector3[4];

    [SerializeField]private float speed;
    [SerializeField] private float range;
    private bool attacking;
    [SerializeField] private float checkdelay;
    [SerializeField] private LayerMask playerlayer;
    private float checktimer;


    private void OnEnable()
    {
        stop();
    }
    private void Update()
    {   
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);

        else
        {
            checktimer += Time.deltaTime;
            if (checktimer > checkdelay)
            {
                checkforplayer();
            }
        }
    }
    private void checkforplayer()
    {
        calculatedirections();
        for (int i = 0; i < directions.Length; i++)
        {

            Debug.DrawRay(transform.position, directions[i],Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i],range,playerlayer);
            if (hit.collider != null&&!attacking)
            {
                attacking = true;
                destination = directions[i];
                checktimer=0; 
            }
        }
        
    }
    private void calculatedirections()
    {
        directions[0] = transform.right * range;//right direction
        directions[1] = -transform.right * range;//left direction
        directions[2] = transform.up * range;//up direction
        directions[3] = -transform.up * range;//down direction

    }
    private void stop()
    {
        destination = transform.position;
        attacking=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision); 
        stop();
    }
}
