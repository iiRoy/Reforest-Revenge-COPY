using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPressStart : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject MenuScreen;

    public Animator fadeBox;
    public AudioSource SFX;

    GameObject currentScreen;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Invoke("Screen", 1f);
            SFX.Play();
            fadeBox.SetInteger("state", 1);
        }
    }   
    void Screen()
    {
        TitleScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }
}
