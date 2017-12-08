using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cursor : MonoBehaviour
{

    private bool selector;
    public Animator anim;
    public GameObject Projetil_X_Med;
    public GameObject projPosition;
    public int selectedScene;
    private bool thisSelected;
    // Use this for initialization
    void Start()
    {
        selectedScene = 1;
        selector = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        selector = false;
        anim.SetBool("select", selector);
        thisSelected = false;

            if (Input.GetKeyUp(KeyCode.S) && thisSelected == false)
        {
            if (transform.position.y == 0.5f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -0.8f);
                selectedScene = 2;
            }
            if (transform.position.y == -0.8f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -2);
                selectedScene = 3;
            }
            if (transform.position.y == -2 && thisSelected == false) 
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -3.4f);
                selectedScene = 4;
            }
            if (transform.position.y == -3.4f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -5);
                selectedScene = 5;
            }
            if (transform.position.y == -5 && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -6.2f);
                selectedScene = 6;
            }
            if (transform.position.y == -6.2f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, 0.5f);
                selectedScene = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {

            if (transform.position.y == 0.5f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -6.2f);
                selectedScene = 6;
            }
            if (transform.position.y == -0.8f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, 0.5f);
                selectedScene = 1;
            }
            if (transform.position.y == -2 && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -0.8f);
                selectedScene = 2;
            }
            if (transform.position.y == -3.4f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -2);
                selectedScene = 3;
            }
            if (transform.position.y == -5 && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -3.4f);
                selectedScene = 4;
            }
            if (transform.position.y == -6.2f && thisSelected == false)
            {
                thisSelected = true;
                transform.position = new Vector2(transform.position.x, -5);
                selectedScene = 5;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            selector = true;
            anim.SetBool("select", selector);
            Indicator();
        }
    }

    public void Indicator()
    {
        GameObject temp = (GameObject)Instantiate(Projetil_X_Med, projPosition.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        temp.GetComponent<Projetil>().Iniciate(Vector2.right);
    }
}
