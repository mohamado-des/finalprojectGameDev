using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
   [SerializeField] private GameObject[] enemies;
    private Vector3[] initalPosition;
    private void Awake()
    {
        initalPosition = new Vector3[enemies.Length];
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i]!=null)
                initalPosition[i]= enemies[i].transform.position;
        }
    }
    public void activateroom(bool _status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(_status);
                enemies[i].transform.position = initalPosition[i];
            }
        }
    }
}
