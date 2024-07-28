using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : enemydamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resettime;
    private float lifetime;
    public void activateprojectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed*Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
        lifetime += Time.deltaTime;
            if (lifetime > resettime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            base.OnTriggerEnter2D(collision);
        gameObject.SetActive(false);
    }

}
