using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public bool sign5;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange){
            if(sign5){
                GameController.Instance.GetComponent<AudioSource>().Pause();
            }
            if(!playerInRange){
                dialogBox.SetActive(false);
            } else {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            other.GetComponent<BarraDeVida>().active = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            other.GetComponent<BarraDeVida>().active = true;
        }
    }

    private void OnTriggerPauseMusic(Collider2D other)
    {
        if(other.CompareTag("Sign 5") && playerInRange == true){
            sign5 = true;
        }
    }
}

