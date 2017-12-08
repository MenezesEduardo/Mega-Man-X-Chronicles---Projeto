using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_jump : MonoBehaviour {

    public Animator anim;
    public Boss boss;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("playerArea", true);
            boss.playerArea = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("playerArea", true);
            boss.playerArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("playerArea", false);
            boss.playerArea = false;
        }

    }
}
