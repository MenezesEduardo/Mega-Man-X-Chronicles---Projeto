using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour {
    public float speed_rotation;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, speed_rotation);
	}
}
