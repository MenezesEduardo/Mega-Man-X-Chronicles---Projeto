using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projetil_X_min" || 
            other.gameObject.tag == "Projetil_X_med" || 
            other.gameObject.tag == "Projetil_X_max" )
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Resources.Load("Songs/hitfail") as AudioClip;
            audioSource.volume = 0.15f;
            audioSource.Play();
        }
    }
}
