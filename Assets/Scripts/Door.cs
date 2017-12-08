using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Animator anim;
    public Animator anim2;
    public int gates;
    private bool aberta;
	// Use this for initialization
	void Start () {
        anim.SetBool("Trancada", true);
        if(anim2 != null)
        {
            anim2.SetBool("Ligado", false);
        }
        aberta = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (gates == 0)
        {
            anim.SetBool("Trancada", false);
            if (anim2 != null)
            {
                anim2.SetBool("Ligado", true);
            }
        }
	}

    public void OpenGate(){
        if (gates > 0) {
            gates -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            aberta = true;
            anim.SetBool("Aberta", aberta);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            aberta = false;
            anim.SetBool("Aberta", aberta);
        }

    }
}
