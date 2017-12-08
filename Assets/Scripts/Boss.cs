using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public bool attack;
    public int lifePoints;
    public bool grounded;
    private bool olhandoDireita;
    public bool middleOfJump;
    public SpriteRenderer spriteRender;
    public Animator anima;
    public Rigidbody2D rigidBody;
    public BoxCollider2D box;
    public CircleCollider2D area;
    public GameObject projetil;
    public GameObject projPosition;
    private float velocityLast;
    private float deathTime;
    private bool secondParticles;
    public PlayerControler player;
    public bool playerArea;
    public GameObject particula;
    public HeathBar life;
    private bool Particles2;
    private float Dtime;

    void Start()
    {
        olhandoDireita = false;
        deathTime = 0;
        secondParticles = false;
        Particles2 = false;
        Dtime = 0;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        velocityLast = rigidBody.velocity.y;
        if (lifePoints >= 1)
        {
            if (spriteRender.isVisible == true) {
                anima.enabled = true;
                if (rigidBody.velocity.y == 0)
                {
                    if (rigidBody.velocity.y - velocityLast == 0) {
                        anima.SetBool("grounded", grounded);
                    }
                    else {
                        anima.SetBool("grounded", grounded);
                    }
                    middleOfJump = false;
                    anima.SetBool("jump", false);
                }
                if (rigidBody.velocity.y >= 0.1)
                {
                    middleOfJump = true;
                    anima.SetBool("jump", true);
                    anima.SetBool("grounded", grounded);
                }
            }
            else
            {
                anima.enabled = false;
            }
        }
        else
        {
            anima.SetBool("dead", true);
            /*box.enabled = false;
            rigidBody.isKinematic = true;*/
            
            AnimationDeath();
        }

    }

    public void Actions()
    {
        if (playerArea == false && grounded == true && gameObject.GetComponent<Renderer>().isVisible == true)
        {
            if (olhandoDireita == false)
            {
                rigidBody.AddForce(new Vector2(-player.transform.position.x * 2, 200), ForceMode2D.Impulse);
            }
            else
            {
                rigidBody.AddForce(new Vector2(player.transform.position.x * 2, 200), ForceMode2D.Impulse);
            }
        }
        flip();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projetil_X_min")
        {
            lifePoints -= 1;
            life.Removelife(1);
            HitSound();
        }
        if (other.gameObject.tag == "Projetil_X_med")
        {
            lifePoints -= 2;
            life.Removelife(2);
            HitSound();
        }
        if (other.gameObject.tag == "Projetil_X_max")
        {
            lifePoints -= 4;
            life.Removelife(4);
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    public void AnimationDeath()
    {
        if (Time.time - Dtime > 0.3)
        {
            Dtime = Time.time;
            GameObject temp6 = (GameObject)Instantiate(particula, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-4, 2), 0), Quaternion.identity);
        }
        if (Time.time - deathTime > 15)
        {
            secondParticles = true;
            deathTime = Time.time;
        }
        if (Time.time - deathTime > 0.2 && secondParticles)
        {
            secondParticles = false;
            Particles2 = true;
        }
        if (Time.time - deathTime > 1.5 && Particles2)
        {
            player.anima.SetBool("End_stage", true);
        }
    }


    public void Attack()
    {
        if (olhandoDireita == false)
        {
            GameObject temp = (GameObject)Instantiate(projetil, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp.GetComponent<Projetil>().Iniciate(Vector2.left);
        }
        else
        {
            GameObject temp = (GameObject)Instantiate(projetil, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            temp.GetComponent<Projetil>().Iniciate(Vector2.right);
        }
    }


    void flip()
    {
        if ((olhandoDireita == false && transform.position.x - player.transform.position.x < 0) || (olhandoDireita == true && transform.position.x - player.transform.position.x > 0))
        {
            olhandoDireita = !olhandoDireita;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }
}
