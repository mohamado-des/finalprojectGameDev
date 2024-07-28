using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


public class healthbar : MonoBehaviour
{
    [SerializeField] private health playerhealth;
    [SerializeField] private Image heatlhbartotal;
    [SerializeField]private Image currenthealthBar;
    private void Start()
    {
        heatlhbartotal.fillAmount = playerhealth.currenthealth / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerhealth.currenthealth/10;
    }

}
