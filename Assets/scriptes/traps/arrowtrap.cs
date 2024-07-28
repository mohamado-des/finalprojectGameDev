using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowtrap : MonoBehaviour
{
   [SerializeField] private float attackcooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldowntimer;
    [SerializeField] private AudioClip arrowsound;

    private void Attack()
    {
        cooldowntimer = 0;
        //soundmanager.instance.playsound(arrowsound);    
        arrows[FindFireball()].transform.position = firepoint.position;
        arrows[FindFireball()].GetComponent<enemyprojectile>().activateprojectile();
    }
    private int FindFireball()
    {
        for (int i = 0; i < arrows.Length; i++)
        {

            if (!arrows [i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (cooldowntimer > attackcooldown)
            Attack();
    }
}
