using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_verde : MonoBehaviour {
    public PlayerControler player;
    public GameObject proj_position_a1;
    public GameObject proj_position_a2;
    public GameObject proj_position_b1;
    public GameObject proj_position_b2;
    public bool cima;
    public bool baixo;
    public bool direita;
    public bool esquerda;
    public Animator anim;

    public GameObject proj_enemy;

    public int lifepoints;
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

    public void SongDestruction()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Songs/destroy") as AudioClip;
        audioSource.volume = 0.15f;
        audioSource.Play();
    }

    public void destruction()
    {
        Destroy(gameObject);
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

    public void attack_alto(){

        if (gameObject.GetComponent<Renderer>().isVisible == true)
        {
            if (baixo)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
                tem.GetComponent<Projetil>().Iniciate(new Vector2(-1, 1));

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_a2.transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
                temp1.GetComponent<Projetil>().Iniciate(new Vector2(1, 1));
            }
            if (cima)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
                tem.GetComponent<Projetil>().Iniciate(new Vector2(1, -1));

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_a2.transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
                temp1.GetComponent<Projetil>().Iniciate(new Vector2(-1, -1));
            }
            if (direita)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
                tem.GetComponent<Projetil>().Iniciate(new Vector2(-1, -1));

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_a2.transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
                temp1.GetComponent<Projetil>().Iniciate(new Vector2(-1, 1));

            }
            if (esquerda)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_a1.transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
                tem.GetComponent<Projetil>().Iniciate(new Vector2(1, 1));

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_a2.transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
                temp1.GetComponent<Projetil>().Iniciate(new Vector2(1, -1));
            }
        }

    }



    public void attack_baixo()
    {
        if (gameObject.GetComponent<Renderer>().isVisible == true)
        {
            if (baixo)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_b1.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.left);

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_b2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp1.GetComponent<Projetil>().Iniciate(Vector2.right);
            }
            if (cima)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_b1.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.right);

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_b2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp1.GetComponent<Projetil>().Iniciate(Vector2.left);
            }

            if (direita)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_b1.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.down);

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_b2.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                temp1.GetComponent<Projetil>().Iniciate(Vector2.up);
            }
            if (esquerda)
            {
                GameObject tem = (GameObject)Instantiate(proj_enemy, proj_position_b1.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tem.GetComponent<Projetil>().Iniciate(Vector2.up);

                GameObject temp1 = (GameObject)Instantiate(proj_enemy, proj_position_b2.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                temp1.GetComponent<Projetil>().Iniciate(Vector2.down);
            }
        }
    }

}
