using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_amarelo : MonoBehaviour {

    public PlayerControler player;
    public int lifepoints;
    public Animator anim;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lifepoints <= 0)
        {
            anim.SetBool("Destroy", true);
        }
    }

    public void destruction()
    {
        Destroy(gameObject);
    }

    public void SongDestruction()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Songs/destroy") as AudioClip;
        audioSource.volume = 0.15f;
        audioSource.Play();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projetil_X_min")
        {
            lifepoints = lifepoints - 1;
            HitSound();
        }
        if (other.gameObject.tag == "Projetil_X_med")
        {
            lifepoints = lifepoints - 2;
            HitSound();
        }
        if (other.gameObject.tag == "Projetil_X_max")
        {
            lifepoints = lifepoints - 4;
            HitSound();
        }
    }

    private void HitSound()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Songs/hit_med") as AudioClip;
        audioSource.volume = 0.15f;
        audioSource.Play();
    }
}
