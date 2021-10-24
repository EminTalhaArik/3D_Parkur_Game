using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUp : MonoBehaviour
{
    public Slider mouseSlider;
    private void Awake()
    {
        //Set Mouse Sensitivity
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensivity = PlayerPrefs.GetFloat("MouseSensitivity",200);

        //Set Mouse Sensitivity Slider
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity",200);
    }
}
