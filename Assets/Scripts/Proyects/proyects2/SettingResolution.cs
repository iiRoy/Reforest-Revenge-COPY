using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingResolution : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown dropdownRes;
    Resolution[] resolutions;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        checkResolution();
    }

    public void ActivateFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void checkResolution()
    {
        resolutions = Screen.resolutions;
        dropdownRes.ClearOptions();
        List<string> options = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }

        dropdownRes.AddOptions(options);
        dropdownRes.value = actualResolution;
        dropdownRes.RefreshShownValue();

        dropdownRes.value = PlayerPrefs.GetInt("resolutionValue", 0);
    }

    public void changeResolution(int indexAspect)
    {
        PlayerPrefs.SetInt("resolutionValue", dropdownRes.value);

        Resolution resolution = resolutions[indexAspect];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
