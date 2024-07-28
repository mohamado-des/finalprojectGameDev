using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollectables : MonoBehaviour
{

    [SerializeField]private float healthValue;
    [SerializeField] private AudioClip healthClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundmanager.instance.playsound(healthClip);
            collision.GetComponent<health>().Addhealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
