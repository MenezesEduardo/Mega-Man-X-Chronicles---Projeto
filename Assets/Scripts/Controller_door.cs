using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_door : MonoBehaviour {
    public Door door;
    private int life_gate;
    public Animator anim_box;
    public Animator anim_switch;
    // Use this for initialization
    void Start()
    {
        life_gate = 1;
        anim_box.SetBool("Ligado", false);
        anim_switch.SetBool("Ligado", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (life_gate >= 1)
        {
            life_gate = 0;
            anim_box.SetBool("Ligado", true);
            anim_switch.SetBool("Ligado", true);
            door.OpenGate();
        }
    }

}
