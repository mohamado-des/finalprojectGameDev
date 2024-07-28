using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeenemy : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField]private float attackcooldown;
    [SerializeField] private int damage;
    [SerializeField] private float collliderDistance;
    private float cooldowntimer=Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField]private LayerMask playerlayer;
    private Animator anim;
    private health playerhealth;
    private enemypatrol enemypatrol;
    [SerializeField] private AudioClip attacksound;
    private void Awake()
    {
        enemypatrol = GetComponentInParent<enemypatrol>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (playerinsight())
        {

            if (cooldowntimer > attackcooldown)
            {
                cooldowntimer = 0;
                anim.SetTrigger("meleeattack");
                soundmanager.instance.playsound(attacksound);
            }
        }
        if(enemypatrol != null)
        {
            enemypatrol.enabled = !playerinsight();
        }
        
    }
    private bool playerinsight()
    {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+transform.right*range*transform.localScale.x*collliderDistance,
            new Vector3(boxCollider.bounds.size.x*range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            ,0,Vector2.left,0,playerlayer);
        if(hit.collider != null)
        {
            playerhealth=hit.transform.GetComponent<health>();
        }
        return hit.collider!=null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.center+transform.right*range*transform.localScale.x*collliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void damageplayer()
    {
        if (playerinsight())
        {
            if(playerinsight())
            {
                playerhealth.Takedamage(damage); 
            }
        }
    }
}
