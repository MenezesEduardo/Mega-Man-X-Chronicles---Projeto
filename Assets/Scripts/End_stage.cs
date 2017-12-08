using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_stage : MonoBehaviour {

    public Door door;
    public PlayerControler player;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (door.gates == 0)
            {
                player.anima.SetBool("End_stage", true);
                player.box.size = new Vector2(player.box.size.x, 0.48f);
            }
        }
    }
}
