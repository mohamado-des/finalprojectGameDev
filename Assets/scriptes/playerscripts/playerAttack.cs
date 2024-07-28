 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField]private AudioClip fireballsound;

    private Animator anim;
    private playermovement playerMovement;
    private float cooldowntimer = Mathf.Infinity;
    private void Awake()
    {
        anim=GetComponent<Animator>();
        playerMovement = GetComponent<playermovement>();

        

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldowntimer>attackcooldown && playerMovement.canAttack())
            Attack();

        cooldowntimer += Time.deltaTime;    
    }
    private void Attack() 
    {
       
        soundmanager.instance.playsound(fireballsound);
        anim.SetTrigger("attack");  
        cooldowntimer = 0;
        fireballs[FindFireBall()].transform.position = firepoint.position;
        fireballs[FindFireBall()].GetComponent<projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }


    private int FindFireBall()
    {

        for (int i = 0; i< fireballs.Length;i++)
        {

            if (!fireballs[i].activeInHierarchy) 
            return i;
        }


        return 0;
    }


}
