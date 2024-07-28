using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selecitionarrow : MonoBehaviour

{
    [SerializeField] private AudioClip interactsound;
    [SerializeField] private AudioClip changesound;
    private int currentPosition;
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeposition(-1);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeposition(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }
    }
    private void changeposition(int _change)
    {
        currentPosition += _change;



        if (_change != 0)
            soundmanager.instance.playsound(changesound);
        if (currentPosition < 0)
        {
            currentPosition = options.Length;
        }
        else if (currentPosition > options.Length - 1)
        {
            currentPosition = 0;
        }
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }
    private void interact()
    {
        soundmanager.instance.playsound(interactsound);

        options[currentPosition].GetComponent<Button>().onClick.Invoke();

    }
}



   
