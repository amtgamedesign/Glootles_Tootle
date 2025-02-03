using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Movement_script : MonoBehaviour
{
    
    //Body parts and changing of movement bool
    public bool Legtype, facingleft;
    public GameObject head;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public Rigidbody2D leftLegRB;
    public Rigidbody2D rightLegRB;
    public Balance_script BodyBalanceScript, leftlegbalance, rightlegbalance;
    public Balance_script HeadBalanceScript;

  //  public SpriteRenderer headsr, bodysr, ullsp, lllsp, urlsp, lrlsp;
    
    
    //Animator
    public Animator anim;
    
    //Speed and how long it takes for a leg to change
    public float speed = 2f;
    [SerializeField] float legWait = .5f;
    

    public GameObject body;
    public TextMeshPro milestext, highscoretext;
    public float miles;
    
    
    
    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
        HeadBalanceScript = head.GetComponent<Balance_script>();
        BodyBalanceScript = body.GetComponent<Balance_script>();
        leftlegbalance = leftLeg.GetComponent<Balance_script>();
        rightlegbalance = rightLeg.GetComponent<Balance_script>();
        
        anim = GetComponent<Animator>();
       // PlayerPrefs.SetInt("highscore",0);
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerPrefs.SetFloat("HighScore", miles);
        // PlayerPrefs.GetFloat("HighScore");
        
        //tracks and displays: meters and high score
        miles = (float)((Mathf.Round(body.transform.position.x * 10)) / 10.0);
        milestext.text = "Miles: " + miles+ "m";
        highscoretext.text = $"High Score: {PlayerPrefs.GetFloat("highscore",0)}";
        if (miles > PlayerPrefs.GetFloat("highscore", 0))
        {
            PlayerPrefs.SetFloat("highscore", miles);
        }
        
        //Changes leg types
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Legtype = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Legtype = true;
        }
        
        if (Legtype == true)
        {
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.DownArrow))
            {
                BodyBalanceScript.targetRotation = 50;
                HeadBalanceScript.targetRotation = 50;
                leftlegbalance.targetRotation = -200;
                rightlegbalance.targetRotation = -200;
            }
        
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                BodyBalanceScript.targetRotation = 0;
                HeadBalanceScript.targetRotation = 0;
                leftlegbalance.targetRotation = 0;
                rightlegbalance.targetRotation = 0;
            }
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.Play("Glootle_Leftfootleft");
                StartCoroutine(MoveLeftfootleft(legWait));
                facingleft = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.Play("Glootle_LeftfootRight");
                StartCoroutine(MoveLeftfootRight(legWait));
                facingleft = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.Play("Glootle_Rightfootleft");
                StartCoroutine(MoveRightfootLeft(legWait));
                facingleft = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.Play("Glootle_RightfootRight");
                StartCoroutine(MoveRightfootRight(legWait));
                facingleft = false;
            }

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                anim.Play("Glootle_idle");
            }
        }

        if (Legtype == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                BodyBalanceScript.targetRotation = 50;
                HeadBalanceScript.targetRotation = 50;
                leftlegbalance.targetRotation = -200;
                rightlegbalance.targetRotation = -200;
            }
        
            if (Input.GetKeyUp(KeyCode.S))
            {
                BodyBalanceScript.targetRotation = 0;
                HeadBalanceScript.targetRotation = 0;
                leftlegbalance.targetRotation = 0;
                rightlegbalance.targetRotation = 0;
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.Play("Glootle_WalkRight");
                    StartCoroutine(MoveRight(legWait));
                    facingleft = false;
                }
                else
                {
                    anim.Play("Glootle_WalkLeft");
                    StartCoroutine(MoveLeft(legWait));
                    facingleft = true;
                }

            }
            else
            {
                anim.Play("Glootle_idle");
            }
        }
        
    }

    
    
    IEnumerator MoveRightfootRight(float seconds)
    {
        rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator MoveLeftfootRight(float seconds)
    {
        leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
    }
    
    IEnumerator MoveRightfootLeft(float seconds)
    {
        rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator MoveLeftfootleft(float seconds)
    {
        leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator MoveRight(float seconds)
    {
        leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
    }

    IEnumerator MoveLeft(float seconds)
    {
        rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
    }
}
