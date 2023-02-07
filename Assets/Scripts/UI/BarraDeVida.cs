using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;
using Platformer.Core;
using Platformer.Gameplay;


public class BarraDeVida : MonoBehaviour
{
    public bool active = true;
    public PlayerController player;
    public Image barraDeVida;

    public float vidaActual;

    public GameObject warningBox;
    public float vidaMaxima = 20;

    void Start() {
        player = GetComponent<PlayerController>();
        vidaActual = vidaMaxima;
        StartCoroutine(Count());
        warningBox.SetActive(false);
    }

    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
        if (vidaActual <= 0) {
            Debug.Log("Muerto por falta agua");
            //Debug.Log("Muerto por falta agua");
            KillPlayer();
        }
        if(vidaActual<8)
        {
            BoxWarningOn();
        }
        if(vidaActual>8)
        {
            BoxWarningOff();
        }
    }
    public void BoxWarningOn()
    {
        warningBox.SetActive(true);
        //Invoke("BoxWarningOff", 3);
    }
    public void BoxWarningOff()
    {
        warningBox.SetActive(false);

    }


    public void ConfigurarVida(int amount)
    {
        if (vidaActual >= vidaMaxima && amount>0)
        {
            return;
        }
        vidaActual += amount;
    }

    public void KillPlayer()
    {
        //player.
        Simulation.Schedule<PlayerDeath>(0);
    }

    public void Reset(){
        this.active = true;
        vidaActual = vidaMaxima;
        StopAllCoroutines();
        StartCoroutine(Count());
    }

    IEnumerator Count() 
    {
     yield return new WaitForSeconds(2);
     if(active) ConfigurarVida(-1);
     StartCoroutine(Count());
    }
}
