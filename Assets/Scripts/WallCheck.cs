using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour {

    public PlayerControler player;
    public GameObject playerobject;
    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Robo_vermelho" &&
             other.gameObject.tag != "Robo_verde" &&
             other.gameObject.tag != "Projetil_enemy_1" &&
             other.gameObject.tag != "Projetil_enemy_2" &&
             other.gameObject.tag != "Robo_amarelo" &&
             other.gameObject.tag != "endPoint" &&
             other.gameObject.tag != "Door" &&
             other.gameObject.tag != "Serra" &&
             other.gameObject.tag != "Saw" &&
             other.gameObject.tag != "Spikes" &&
             other.gameObject.tag != "Acido" &&
             other.gameObject.tag != "Gate_Door" &&
             other.gameObject.tag != "Boss_Door" &&
             other.gameObject.tag != "Boss")
        {
            player.walled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        playerobject.layer = 0;
        if (other.gameObject.tag != "Robo_vermelho" &&
             other.gameObject.tag != "Robo_verde" &&
             other.gameObject.tag != "Projetil_enemy_1" &&
             other.gameObject.tag != "Projetil_enemy_2" &&
             other.gameObject.tag != "Robo_amarelo" &&
             other.gameObject.tag != "endPoint" &&
             other.gameObject.tag != "Door" &&
             other.gameObject.tag != "Serra" &&
             other.gameObject.tag != "Saw" &&
             other.gameObject.tag != "Spikes" &&
             other.gameObject.tag != "Acido" &&
             other.gameObject.tag != "Gate_Door" &&
             other.gameObject.tag != "Boss_Door" &&
             other.gameObject.tag != "Boss")
        {
            player.walled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.walled = false;
    }
}
