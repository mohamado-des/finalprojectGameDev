using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerrespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checpoinsound;
    private Transform currentcheckpoint;
    private health playerhealth;
    private uimanager managerui;
   
    private void Awake()
    {
        playerhealth = GetComponent<health>();
        managerui = FindObjectOfType<uimanager>();
    }
    public void checkrespawn()
    {
        if (currentcheckpoint == null)
        {
            managerui.GameOver();
            return;
        }
        transform.position = currentcheckpoint.position;
        playerhealth.respawn();
        Camera.main.GetComponent<CameraControlle>().MoveToNewRoom(currentcheckpoint.parent);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "checkpoint")
        {
            currentcheckpoint = collision.transform;
            //playsound
            soundmanager.instance.playsound(checpoinsound);     
            collision.GetComponent<Animator>().SetTrigger("appear");
            collision.GetComponent<Collider2D>().enabled = false;

        }
    }
}
