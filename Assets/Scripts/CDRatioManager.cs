using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDRatioManager : MonoBehaviour
{
    public GameObject CDRatioOnText;
    public GameObject CDRatioOffText;
    public GameObject OnButton;
    public GameObject OffButton;

    void Start()
    {
        //Switch C/D ratio on when application starts
        SwitchOn();
    }

    public void SwitchOn()
    {
        GameConfiguration.CDRatio = true;
        CDRatioOnText.SetActive(true);
        CDRatioOffText.SetActive(false);
        OnButton.SetActive(false);
        OffButton.SetActive(true);
    }

    public void SwitchOff()
    {
        GameConfiguration.CDRatio = false;
        CDRatioOnText.SetActive(false);
        CDRatioOffText.SetActive(true);
        OnButton.SetActive(true);
        OffButton.SetActive(false);
    }
}
