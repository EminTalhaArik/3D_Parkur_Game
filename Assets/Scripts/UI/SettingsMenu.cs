using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomix;
    private bool isFullScreen = true;

    public void SetResolution(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(1920, 1080, isFullScreen);
        }
        else if (index == 1)
        {
            Screen.SetResolution(1360, 768, isFullScreen);
        }
        else
        {
            Screen.SetResolution(1280, 720, isFullScreen);
        }
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool fullSceenEnable)
    {
        isFullScreen = fullSceenEnable;
        Screen.fullScreen = fullSceenEnable;
    }

    public void SetMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensivity = value;
        }
    }

    public void SetMasterVolume(float value)
    {
        audiomix.SetFloat("MasterVolume", value);
    }

}
