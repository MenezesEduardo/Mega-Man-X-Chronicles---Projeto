using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBar : MonoBehaviour {

    public GameObject[] life;
    public int damage_taken;
    // Use this for initialization
    void Start () {
        damage_taken = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Removelife(int damage)
    {
        for (int i = 0; i < damage ; i++) 
        {
            Destroy(life[damage_taken]);
            damage_taken += 1;
        }
    }
}
