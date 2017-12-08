using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projetil : MonoBehaviour
{
    public Animator anima;
    public float speed;
    public AudioSource hitsong;
    private Rigidbody2D myrigidbody;

    private Vector2 direction;
    // Use this for initialization
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        //direction = Vector2.right;
    }

    public void Iniciate(Vector2 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        myrigidbody.velocity = direction * speed;
    }
    // Update is called once per frame
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        anima.SetBool("hit", true);
        myrigidbody.velocity = new Vector2(0,0);
       // Destroy(gameObject);

    }


    public void HitSong()
    {
        if (hitsong != null)
        {
            hitsong.Play();
        }
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
}
