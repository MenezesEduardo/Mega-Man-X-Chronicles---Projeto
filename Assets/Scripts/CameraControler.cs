using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControler : MonoBehaviour {


    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;

    private Transform target;
    public GameObject player;       //Public variable to store a reference to the player game object
    public SpriteRenderer lockwall;
    private GameObject target2;
    private GameObject target3;
    //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            target = GameObject.Find("Player").transform;
        }
        else
        {
            target = null;
        }
        target2 = GameObject.Find("thislock1");
        target3 = GameObject.Find("thislock2");
        if (target3 != null && target2 != null)
        {
            target3.SetActive(false);
            target2.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name != "0_Menu")
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (lockwall != null)
        {
            if (lockwall.isVisible)
            {
                target = GameObject.Find("center").transform;
                if (target3 != null && target2 != null)
                {
                    target3.SetActive(true);
                    target2.SetActive(true);
                }
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.transform.position, 2 * Time.deltaTime);

                // transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
            }
            else
            {
                if (target != null)
                {
                    transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
                }
            }
        }
        else
        {
            if (target != null)
            {
                transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
            }
        }


    }
}
