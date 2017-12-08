using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfWalk: MonoBehaviour
{    public bool parado;
    public bool virar;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextpos;
    public float speed_moving;
    public Transform childtransform;
    public Transform transformB;
    public SpriteRenderer spriteRender;
    public Animator anim;
   // private bool virou;

    // Use this for initialization
    void Start()
    {
        //virou = false;
        posA = childtransform.localPosition;
        posB = transformB.localPosition;
        nextpos = posB;

    }

    private void Move()
    {
       
        if ( spriteRender != null)
        {
            if (spriteRender.isVisible == true || gameObject.tag == "Plataform")
            {
                childtransform.localPosition = Vector3.MoveTowards(childtransform.localPosition, nextpos, speed_moving * Time.deltaTime);

                if (Vector3.Distance(childtransform.localPosition, nextpos) <= 1)
                {
                    if (anim != null)
                    {
                        anim.SetBool("virar", true);
                    }
                }

                if (Vector3.Distance(childtransform.localPosition, nextpos) <= 0.1)
                {
                    changePos();
                }
            }
        }
    }


    
    // Update is called once per frame
    void Update()
    {
        if (parado == false) {
            Move();
        }
    }

    void changePos()
    {
        Vector3 escala = transform.localScale;
        nextpos = nextpos != posA ? posA : posB;
        if (virar == true)
        {
            spriteRender.flipX = !spriteRender.flipX;
            if (anim != null)
            {
                anim.SetBool("virar", false);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = 8;
            other.transform.SetParent(childtransform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }



}
