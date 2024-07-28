using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class health : MonoBehaviour
{
    [Header("Health")]
    private bool dead;
    [SerializeField] private float startinghealth;
    public float currenthealth {  get; private set; }
    private Animator anim;
    [Header("iframes")]
    [SerializeField]private float iframesDuration;
    [SerializeField]private int numberoffflashes;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip deathsound;
    [SerializeField] private AudioClip hurtsound;


    private void Awake()
    {
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Takedamage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);
        if (currenthealth > 0)
        {


            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            soundmanager.instance.playsound(hurtsound);
        }
        else
        {
            if (!dead)
            {

                if (GetComponent<playermovement>() != null)
                    GetComponent<playermovement>().enabled = false;
                if (GetComponent<enemypatrol>() != null)
                    GetComponentInParent<enemypatrol>().enabled = false;
                if (GetComponent<meleeenemy>() != null)
                    GetComponent<meleeenemy>().enabled = false;
                anim.SetTrigger("die");
                dead = true;
                soundmanager.instance.playsound(deathsound);
            }
        }
    }
    public void Addhealth(float _value)
    
    {
        currenthealth = Mathf.Clamp(currenthealth + _value, 0, startinghealth);
    }
     public void respawn()
    {
        dead = false;
       Addhealth(startinghealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        StartCoroutine(Invunerability());
        if (GetComponent<playermovement>() != null)
            GetComponent<playermovement>().enabled = true;
        if (GetComponent<enemypatrol>() != null)
            GetComponentInParent<enemypatrol>().enabled = true;
        if (GetComponent<meleeenemy>() != null)
            GetComponent<meleeenemy>().enabled = true;
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10,11,true);
        for (int i = 0; i < numberoffflashes; i++)
        {
            spriteRenderer.color=new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iframesDuration/(numberoffflashes*2));

            spriteRenderer.color=Color.white;
            yield return new WaitForSeconds(iframesDuration/(numberoffflashes*2));

        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }

}
