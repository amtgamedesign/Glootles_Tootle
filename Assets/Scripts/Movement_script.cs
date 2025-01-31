using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement_script : MonoBehaviour
{
    //Body parts and changing of movement bool
    public bool Legtype;
    public GameObject head;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public Rigidbody2D leftLegRB;
    public Rigidbody2D rightLegRB;
    public Rigidbody2D bodyrb;
    public Rigidbody2D headrb;
    
    
    //Animator
    Animator anim;
    
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
        headrb = head.GetComponent<Rigidbody2D>();
        bodyrb = body.GetComponent<Rigidbody2D>();
        
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play("bendingani");
            //StartCoroutine(Bending(legWait));
            Debug.Log("button is working");
        }
        
        
        
        if (Legtype == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.Play("Leftfootleft");
                StartCoroutine(MoveLeftfootleft(legWait));
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.Play("LeftfootRight");
                StartCoroutine(MoveLeftfootRight(legWait));
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.Play("Rightfootleft");
                StartCoroutine(MoveRightfootLeft(legWait));
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.Play("RightfootRight");
                StartCoroutine(MoveRightfootRight(legWait));
            }

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                anim.Play("idle");
            }
        }

        if (Legtype == false)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {

                    anim.Play("walkright");
                    StartCoroutine(MoveRight(legWait));
                }
                else
                {
                    anim.Play("walkleft");
                    StartCoroutine(MoveLeft(legWait));

                }

            }
            else
            {
                anim.Play("idle");
            }
        }
        
    }

    
    IEnumerator Bending(float seconds)
    {
        Debug.Log("Coruteen is working");
        headrb.AddForce(Vector2.right * (3 * 1000) * Time.deltaTime);
        bodyrb.AddForce(Vector2.right * (3 * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
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
