using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGroundCheck : MonoBehaviour {
    public Boss boss;
    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        boss.grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        boss.grounded = false;
    }
}

