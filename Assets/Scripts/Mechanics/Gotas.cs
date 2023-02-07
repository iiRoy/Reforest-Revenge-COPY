using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotas : MonoBehaviour
{
    public int amountVida;
    public AudioClip tokenCollectAudio;
    [Tooltip("If true, animation will start at a random position in the sequence.")]
    public bool randomAnimationStartTime = false;
    [Tooltip("List of frames that make up the animation.")]
    public Sprite[] idleAnimation, collectedAnimation;

    internal Sprite[] sprites = new Sprite[0];

    internal SpriteRenderer _renderer;

    //unique index which is assigned by the TokenController in a scene.
    internal int tokenIndex = -1;
 
    //active frame in animation, updated by the controller.
    internal int frame = 0;
    internal bool collected = false;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (randomAnimationStartTime)
            frame = Random.Range(0, sprites.Length);
        sprites = idleAnimation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //only exectue OnPlayerEnter if the player collides with this token.
        if (other.gameObject.tag == ("Player"))
        {
            OnPlayerEnter();
            other.gameObject.GetComponent<BarraDeVida>().ConfigurarVida(amountVida);
        }


    }

    void OnPlayerEnter()
    {

        sprites = collectedAnimation;
        gameObject.SetActive(false);

    }
}

