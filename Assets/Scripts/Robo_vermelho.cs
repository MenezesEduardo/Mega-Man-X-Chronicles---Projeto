using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_vermelho : MonoBehaviour {

    public PlayerControler player;
    public int lifepoints;
    public GameObject proj_position_a1;
    public GameObject proj_position_bd;
    public GameObject proj_position_be;
    public bool cima;
    public bool baixo;
    public bool direita;
    public bool esquerda;
    public Animator anim;
    public GameObject proj_enemy_1;
    public GameObject proj_enemy_2;
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

    public void attack_central()
    {
        if (gameObject.GetComponent<Renderer>().isVisible == true) {
            if (baixo)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_2, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.up);
            }
            if (cima)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_2, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.down);
            }
            if (direita)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_2, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.left);

            }
            if (esquerda)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_2, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, -180)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.right);
            }
        }
 
    }

    public void attack_direita()
    {
        if (gameObject.GetComponent<Renderer>().isVisible == true)
        {
            if (baixo)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_bd.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.right);
            }
            if (cima)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_bd.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.left);
            }
            if (direita)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_bd.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.up);

            }
            if (esquerda)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_bd.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.down);
            }
        }

    }



    public void attack_esquerda()
    {
        if (gameObject.GetComponent<Renderer>().isVisible == true)
        {
            if (baixo)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_be.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.left);
            }
            if (cima)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_be.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.right);
            }

            if (direita)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_be.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.down);
            }
            if (esquerda)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy_1, proj_position_be.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.up);
            }
        }
    }

}
