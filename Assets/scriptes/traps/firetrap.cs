using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("firetrap timer")]
     [SerializeField] private float activationtimedelay;
    [SerializeField] private float activetime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool triggered;
    private bool active;
    [SerializeField] AudioClip firetrapsound;
    private void Awake()
    {
        anim= GetComponent<Animator>();
        spriteRend= GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    
        if (collision.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(activefiretrap());
               
            }
            if (active)
            {
                
                collision.GetComponent<health>().Takedamage(damage);
            }
             
        }
    }  
    private IEnumerator activefiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activationtimedelay);
        spriteRend.color = Color.white;
        soundmanager.instance.playsound(firetrapsound);
        active = true;
        anim.SetBool("activated",true);
        yield return new WaitForSeconds(activetime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);

    }
}
