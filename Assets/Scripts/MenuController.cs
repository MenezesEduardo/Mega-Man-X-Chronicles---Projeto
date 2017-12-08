using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuController : MonoBehaviour {

    public Text stage1Text;
    public Text stage2Text;
    public Text stage3Text;
    public Text stage4Text;
    public Text stageBossText;
    public Animator anim;
    public Canvas yourCanvas;


    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1")) {
            Stage01();
           
        }
        if (Input.GetKeyDown("2")){
            Stage02();
            
        }
        if (Input.GetKeyDown("3"))
        {
            Stage03();

        }
        if (Input.GetKeyDown("4"))
        {
            Stage04();

        }
        if (Input.GetKeyDown("5"))
        {
            StageBoss();

        }


    }


   

    public void Stage01()
    {
        // (string x,int x, boolean x, object x )
        Debug.LogWarning("Stage 01");
        //anim.Play("MenuAnimation");
        ;// SceneManager.LoadScene("NewScene");
        //GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas_Menu");
        //Transform textTr = yourCanvas.transform.Find("Stage01Text");
        //Text text = textTr.GetComponent<Text>();
        stage1Text.color = Color.yellow;
        stage2Text.color = new Color(132, 198, 246);
        stage3Text.color = new Color(132, 198, 246);
        stage4Text.color = new Color(132, 198, 246);
        stageBossText.color = new Color(132, 198, 246);
        ;
    }
    public void Stage02()
    {
        // (string x,int x, boolean x, object x )
        Debug.LogWarning("Stage 02");
        stage1Text.color = new Color(132, 198, 246, 255);
        stage2Text.color = Color.yellow;
        stage3Text.color = new Color(132, 198, 246);
        stage4Text.color = new Color(132, 198, 246);
        stageBossText.color = new Color(132, 198, 246);
        

        anim.Play("MenuAnimation");
        

        ;// SceneManager.LoadScene("NewScene");
    }
    public void Stage03()
    {
        // (string x,int x, boolean x, object x )
        Debug.LogWarning("Stage 03");
        ;// SceneManager.LoadScene("NewScene");
        stage1Text.color = new Color(132, 198, 246);
        stage2Text.color = new Color(132, 198, 246);
        stage3Text.color = Color.yellow; 
        stage4Text.color = new Color(132, 198, 246);
        stageBossText.color = new Color(132, 198, 246);
    }
    public void Stage04()
    {
        // (string x,int x, boolean x, object x )
        Debug.LogWarning("Stage 04");
        stage1Text.color = new Color(132, 198, 246);
        stage2Text.color = new Color(132, 198, 246);
        stage3Text.color = new Color(132, 198, 246);
        stage4Text.color = Color.yellow;
        stageBossText.color = new Color(132, 198, 246);
        ;// SceneManager.LoadScene("NewScene");
    }
    public void StageBoss()
    {
        // (string x,int x, boolean x, object x )
        Debug.LogWarning("Stage Boss");
        stage1Text.color = new Color(132, 198, 246);
        stage2Text.color = new Color(132, 198, 246);
        stage3Text.color = new Color(132, 198, 246);
        stage4Text.color = new Color(132, 198, 246);
        stageBossText.color = Color.yellow;  
        ;// SceneManager.LoadScene("NewScene");
    }

}
