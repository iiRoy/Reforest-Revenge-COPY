using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingQuality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;

    void Start()
    {
        quality = PlayerPrefs.GetInt("list value", 3);
        dropdown.value = quality;
        qualitySet();
    }

    public void qualitySet()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("list value", dropdown.value);
        quality = dropdown.value;
    }
}
