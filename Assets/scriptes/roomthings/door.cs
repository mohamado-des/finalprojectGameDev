using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField]private Transform previousroom;
    [SerializeField] private Transform nextroom;
    [SerializeField] private CameraControlle cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextroom);
                nextroom.GetComponent<room>().activateroom(true);
                previousroom.GetComponent<room>().activateroom(false);

            }
            else
            {
                cam.MoveToNewRoom(previousroom);
                nextroom.GetComponent<room>().activateroom(false);
                previousroom.GetComponent<room>().activateroom(true);
            }
        }
    }
}
