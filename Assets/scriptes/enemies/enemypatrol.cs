using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemypatrol : MonoBehaviour
{
    [SerializeField] private Transform leftedge;
    [SerializeField] private Transform rightedge;
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingleft;
    [SerializeField]private Animator anim;
    [SerializeField] private float idledurtaion;
    private float idletimer;
    private void Awake()
    {
        
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    private void Update()
    {
        if (movingleft)
        {
            if (enemy.position.x >= leftedge.position.x)
            {
                moveindirection(-1);
            }
            else
            {
                directionchnage();
            }
        }
        else {
            if (enemy.position.x <= rightedge.position.x)
            {
                moveindirection(1);
            }
            else
                directionchnage();
            
        }
    }
    private void directionchnage()
    {
        idletimer += Time.deltaTime; 
        anim.SetBool("moving", false);
        if(idletimer>idledurtaion)
             movingleft =!movingleft;
    }
    private void moveindirection(int _direction)
    {
        idletimer = 0;
        anim.SetBool("moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x)*_direction,initScale.y,initScale.z);
    enemy.position= new Vector3(enemy.position.x+Time.deltaTime*_direction*speed,enemy.position.y,enemy.position.z);
    }
}
