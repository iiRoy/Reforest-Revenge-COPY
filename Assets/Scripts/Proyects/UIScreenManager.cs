using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenManager : MonoBehaviour
{
    public UIAudioManager audioManager;
    public GameObject[] screens;
    public Animator fadeBox;

    GameObject currentScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioManager.PlaySFX(2);
            screens[1].SetActive(false);
            screens[2].SetActive(false);
            screens[3].SetActive(false);
        }
    }
    public void EnableScreen(int index)
    {
        currentScreen = screens[index];
        currentScreen.SetActive(true);
    }

    public void DisableScreen(int index)
    {
        screens[index].SetActive(false);
    }

    public void Fade()
    {
        fadeBox.Play("FadeInOut");
    }
}
