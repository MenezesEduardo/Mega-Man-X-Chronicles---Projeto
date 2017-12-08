using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float lastspeed;
    public bool middleOfJump;
    public bool walking;
    public bool walled;
    public bool attack;
    public bool grounded;
    public int lifePoints;
    private bool olhandoDireita;
    public SpriteRenderer spriteRender;
    public Animator anima;
    public Animator animCarga;
    public Animator animWall;
    public Rigidbody2D rigidBody;
    public BoxCollider2D box;
    public GameObject Projetil_X_Min;
    public GameObject Projetil_X_Med;
    public GameObject Projetil_X_Max;
    public GameObject projPosition;
    public GameObject projPosition2;
    public GameObject particula;
    private float deathTime;
    public AudioSource[] Songs;
    private AudioSource chargesong3;
    private AudioSource chargesong2;
    private bool Particles1;
    private bool Particles2;
    public HeathBar life;
    //private float carregando;
    private float lastTime;
    // Use this for initialization
    void Start()
    {
        anima.SetBool("dead", false);
        olhandoDireita = true;
        deathTime = 0;
        Particles1 = false;
        Particles2 = false;
        //lastspeed = rigidBody.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoints >= 1 && anima.GetBool("End_stage") == false)
        {
            attack = false;
            walking = false;
            Vector3 posAtual = transform.position;
            anima.SetBool("grounded", grounded);
            anima.SetBool("walled", walled);
            anima.SetBool("middleJump", middleOfJump);
            animWall.SetBool("hit", false);
            animWall.SetBool("walled", false);

            if (Input.GetKey(KeyCode.J))
            {
                animCarga.SetBool("carga_1", false);
                animCarga.SetBool("carga_2", false);

                if (Time.time - lastTime > 0.5 && Time.time - lastTime < 1)
                {
                    animCarga.SetBool("carga_1", true);
                    animCarga.SetBool("carga_2", false);
                }

                if (Time.time - lastTime >= 1)
                {
                    animCarga.SetBool("carga_1", false);
                    animCarga.SetBool("carga_2", true);
                }
            }

            if (Input.GetKeyDown(KeyCode.J)) {
                lastTime = Time.time;
                //carregando = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                attack = true;
                anima.SetBool("attack", attack);
                spriteRender.color = new Color(255, 255, 255);
                if (walled)
                {
                    AttackWalled();
                }
                else
                {
                    Attack();
                }
                return;
            }
            anima.SetBool("attack", attack);
            if (Input.GetAxis("Horizontal") < -0.1f)
            {
                if (walled == false)
                {
                    walking = true;
                    anima.SetBool("walking", walking);
                }
                if (walled == true)
                {
                    anima.SetBool("walled", walled);
                } else {
                    anima.SetBool("walled", walled);
                }
                if (Input.GetButtonDown("Jump"))
                {
                    if (grounded == true)
                    {
                        gameObject.layer = 9;
                        rigidBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                    }
                    if (walled == true && middleOfJump == false && grounded == false) {
                        rigidBody.AddForce(new Vector2(-rigidBody.velocity.x * 10, jumpSpeed * 1.5f), ForceMode2D.Impulse);
                        anima.SetBool("walled", walled);
                        animWall.SetBool("hit", true);
                        animWall.SetBool("walled", true);

                    }
                }
                return;
            }

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                if (walled == false)
                {
                    walking = true;
                    anima.SetBool("walking", walking);
                }
                if (walled == true)
                {
                    anima.SetBool("walled", walled);
                } else {
                    anima.SetBool("walled", walled);
                }
                if (Input.GetButtonDown("Jump"))
                {
                    if (grounded == true)
                    {
                        gameObject.layer = 9;
                        rigidBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                    }
                    if (walled == true && middleOfJump == false && grounded == false)
                    {
                        rigidBody.AddForce(new Vector2(-rigidBody.velocity.x * 10, jumpSpeed * 1.5f), ForceMode2D.Impulse);
                        animWall.SetBool("hit", true);
                        animWall.SetBool("walled", true);
                    }
                }
                return;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (grounded == true)
                {
                    gameObject.layer = 9;
                    rigidBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                }
                if (walled == true && middleOfJump == false && grounded == false)
                {
                    rigidBody.AddForce(new Vector2(-rigidBody.velocity.x * 10, jumpSpeed * 1.5f), ForceMode2D.Impulse);
                    animWall.SetBool("hit", true);
                    animWall.SetBool("walled", true);

                }
            }
            anima.SetBool("walking", walking);
            anima.SetBool("walled", walled);
        }
        else
        {
            if (anima.GetBool("End_stage") != true)
            {
                anima.SetBool("dead", true);
                anima.SetBool("middleJump", false);
                anima.SetBool("grounded", false);
                anima.SetBool("walking", false);
                animWall.SetBool("hit", false);
                animWall.SetBool("walled", false);
                rigidBody.gravityScale = 0;
                rigidBody.velocity = new Vector2(0, 0);
                AnimationDeath();
            }
        }
    }

    void Moviment(float horizontal) {
        if (anima.GetBool("End_stage") == false && anima.GetBool("hit") == false)
        {
            if (walled == true)
            {
                if (middleOfJump)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
                }
                else
                {
                    if (grounded == false)
                    {
                        rigidBody.velocity = new Vector2(rigidBody.velocity.x, (rigidBody.velocity.y * 0.9f));
                        animWall.SetBool("hit", false);
                        animWall.SetBool("walled", true);
                    }
                }
            }
            else
            {
                rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
                anima.SetBool("walled", false);
                animWall.SetBool("walled", false);
            }

            flip(horizontal);
        }
        else {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }
    public void hited() {
        anima.SetBool("hit", false);
    }

    private void FixedUpdate()
    {
        if (lifePoints >= 1 && anima.GetBool("hit") == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            Moviment(horizontal);

            if (rigidBody.velocity.y <= 0)
            {
                gameObject.layer = 9;
                middleOfJump = false;
                anima.SetBool("middleJump", false);

            }
            if (rigidBody.velocity.y >= 0.1)
            {
                gameObject.layer = 9;
                middleOfJump = true;
                anima.SetBool("middleJump", true);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Serra" ||
            other.gameObject.tag == "Saw" ||
            other.gameObject.tag == "Spikes" ||
            other.gameObject.tag == "Acido")
        {
            rigidBody.velocity = new Vector2(-rigidBody.velocity.x, rigidBody.velocity.y);
            anima.SetBool("hit", true);
            lifePoints = 0;
            life.Removelife(25);
        }
        if (other.gameObject.tag == "Robo_vermelho" ||
            other.gameObject.tag == "Robo_verde" ||
            other.gameObject.tag == "Projetil_enemy_1")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
            anima.SetBool("hit", true);
            AddLifePoints(-2);
            life.Removelife(2);
            HitSound();
        }
        if (other.gameObject.tag == "Projetil_enemy_2" ||
            other.gameObject.tag == "Robo_amarelo" ||
            other.gameObject.tag == "Projetil_Boss" ||
            other.gameObject.tag == "Boss")
        {
            rigidBody.velocity = new Vector2(-rigidBody.velocity.x, rigidBody.velocity.y);
            anima.SetBool("hit", true);
            AddLifePoints(-4);
            life.Removelife(4);
            HitSound();
        }
    }

    private void HitSound()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Songs/hit_enemy") as AudioClip;
        audioSource.volume = 0.15f;
        audioSource.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anima.SetBool("hit", false);
    }

    public void AddLifePoints(int points)
    {
        this.lifePoints += points;
    }
    public void End_song()
    {
        chargesong3 = (AudioSource)Instantiate(Songs[3]);
        chargesong3.Play();
    }

    public void End_stage()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "1_Armazem")
        {
            SceneManager.LoadScene(2);
        }
        if (scene.name == "2_Subsolo")
        {
            SceneManager.LoadScene(3);
        }
        if (scene.name == "3_Reactor")
        {
            SceneManager.LoadScene(4);
        }
        if (scene.name == "4_Laboratorio")
        {
            SceneManager.LoadScene(5);
        }
        if (scene.name == "5_FinalBoss")
        {
            SceneManager.LoadScene(6);
        }
    }
    
    public void deathSong()
    {
        chargesong3 = (AudioSource)Instantiate(Songs[2]);
        chargesong3.Play();
    }

    public void AnimationDeath()
    {
        if(Time.time - deathTime > 2.5)
        {
            deathTime = Time.time;
            Particles1 = true;
            GameObject temp6 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp6.GetComponent<Projetil>().Iniciate(Vector2.right);
            GameObject temp7 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp7.GetComponent<Projetil>().Iniciate(Vector2.left);
            GameObject temp8 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp8.GetComponent<Projetil>().Iniciate(Vector2.down);
            GameObject temp9 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp9.GetComponent<Projetil>().Iniciate(Vector2.up);
            GameObject temp1 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp1.GetComponent<Projetil>().Iniciate(new Vector2(-1, 1));
            GameObject temp2 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp2.GetComponent<Projetil>().Iniciate(new Vector2(1, 1));
            GameObject temp3 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp3.GetComponent<Projetil>().Iniciate(new Vector2(-1, -1));
            GameObject temp4 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp4.GetComponent<Projetil>().Iniciate(new Vector2(-1, -1));
            GameObject temp5 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp5.GetComponent<Projetil>().Iniciate(new Vector2(1, -1));

        }
        if (Time.time - deathTime > 1.5 && Particles1)
        {
            Particles1 = false;
            Particles2 = true;
            GameObject temp2 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp2.GetComponent<Projetil>().Iniciate(new Vector2(1, 0.5f));
            GameObject temp3 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp3.GetComponent<Projetil>().Iniciate(new Vector2(0.5f, 1));
            GameObject temp4 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp4.GetComponent<Projetil>().Iniciate(new Vector2(-0.5f, 1));
            GameObject temp5 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp5.GetComponent<Projetil>().Iniciate(new Vector2(-1, 0.5f));
            GameObject temp6 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp6.GetComponent<Projetil>().Iniciate(new Vector2(-1, -0.5f));
            GameObject temp7 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp7.GetComponent<Projetil>().Iniciate(new Vector2(-0.5f, -1));
            GameObject temp8 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp8.GetComponent<Projetil>().Iniciate(new Vector2(0.5f, -1));
            GameObject temp9 = (GameObject)Instantiate(particula, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp9.GetComponent<Projetil>().Iniciate(new Vector2(1, -0.5f));
        }
        if (Time.time - deathTime > 2 && Particles2)
        {
            Particles1 = false;
            Particles2 = false;
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "1_Armazem")
            {
                SceneManager.LoadScene(1);
            }
            if (scene.name == "2_Subsolo")
            {
                SceneManager.LoadScene(2);
            }
            if (scene.name == "3_Reactor")
            {
                SceneManager.LoadScene(3);
            }
            if (scene.name == "4_Laboratorio")
            {
                SceneManager.LoadScene(4);
            }
            if (scene.name == "5_FinalBoss")
            {
                SceneManager.LoadScene(5);
            }
        }
    }

    public void Attack()
    {
        if (olhandoDireita == true)
        {
            if (Time.time - lastTime <= 0.5)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Min, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.right);
            }
            if (Time.time - lastTime > 0.5 && Time.time - lastTime < 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Med, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.right);
                
            }
            if (Time.time - lastTime >= 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Max, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.right);
                
            }
            animCarga.SetBool("carga_1", false);
            animCarga.SetBool("carga_2", false);
        }
        else
        {
            if (Time.time - lastTime <= 0.5)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Min, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.left);
            }
            if (Time.time - lastTime > 0.5 && Time.time - lastTime < 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Med, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.left);
            }
            if (Time.time - lastTime >= 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Max, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.left);
            }
            animCarga.SetBool("carga_1", false);
            animCarga.SetBool("carga_2", false);
        }
    }

    public void AttackWalled()
    {
        if (olhandoDireita == true)
        {
            if (Time.time - lastTime <= 0.5)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Min, projPosition2.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.left);
            }
            if (Time.time - lastTime > 0.5 && Time.time - lastTime < 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Med, projPosition2.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.left);
            }
            if (Time.time - lastTime >= 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Max, projPosition2.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.left);
            }

            animCarga.SetBool("carga_1", false);
            animCarga.SetBool("carga_2", false);
        }
        else
        {
            if (Time.time - lastTime <= 0.5)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Min, projPosition2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.right);
            }
            if (Time.time - lastTime > 0.5 && Time.time - lastTime < 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Med, projPosition2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.right);
            }
            if (Time.time - lastTime >= 1)
            {
                GameObject temp = (GameObject)Instantiate(Projetil_X_Max, projPosition2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                temp.GetComponent<Projetil>().Iniciate(Vector2.right);
            }
            animCarga.SetBool("carga_1", false);
            animCarga.SetBool("carga_2", false);
        }
    }

    void flip(float horizontal)
    {
        if ((horizontal > 0 && !olhandoDireita) || (horizontal < 0 && olhandoDireita))
        {
            olhandoDireita = !olhandoDireita;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }
}
   