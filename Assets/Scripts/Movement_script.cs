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
    [SerializeField] float jump;
    public bool onground;
    public float positionradius;
    public LayerMask ground;
    public Transform playerpos;
    public Rigidbody2D rb, headrb;
    

    public GameObject body;
    public TextMeshPro milestext, highscoretext;
    public float miles;
    
    // private var
    private bool inputA = false;
    private bool inputD = false;
    private bool inputRAR = false;
    private bool inputLAR = false;
    private bool inputS = false;
    private bool inputDAR = false;
    private bool inputW = false;
    private bool inputUAR = false;
    
    
    
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

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            inputA = true;
        }
        else
        {
            inputA = false;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            inputD = true;
            Debug.Log("inputD = true");
        }
        else
        {
            inputD = false;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputLAR = true;
        }
        else
        {
            inputLAR = false;
        }
        
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputRAR = true;
        }
        else
        {
            inputRAR = false;
        }
        
        
        if (Input.GetKey(KeyCode.W))
        {
            inputW = true;
        }
        else
        {
            inputW = false;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputUAR = true;
        }
        else
        {
            inputUAR = false;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            inputS = true;
        }
        else
        {
            inputS = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputDAR = true;
        }
        else
        {
            inputDAR = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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
        
        
        //This is two player:
        if (Legtype == true)
        {
            onground = Physics2D.OverlapCircle(playerpos.position, positionradius, ground);
            if (onground == true && inputW && inputUAR)
            {
                rb.AddForce(jump * Vector2.up);
            }
            
            if (Input.GetAxisRaw("Horizontal") == 0 || inputA && inputRAR || inputD && inputLAR || inputD && inputA || inputLAR && inputRAR)
            {
                anim.Play("Glootle_idle");
            }
            //Left leg left
            else if (inputA && !inputLAR)
            {
                anim.Play("Glootle_Leftfootleft");
                StartCoroutine(MoveLeftfootleft(legWait));
                facingleft = true;
            }
            //Left leg Right
            else if (inputD && !inputRAR)
            {
                Debug.Log(leftLegRB.totalForce.x);
                Debug.Log("D leg move");
                anim.Play("Glootle_LeftfootRight");
                // we only want to do this in the case where there isnt already force being applied
                StartCoroutine(MoveLeftfootRight(legWait));
                facingleft = false;
            }
            
            if (Input.GetAxisRaw("Horizontal") == 0 || inputA && inputRAR || inputD && inputLAR || inputD && inputA || inputLAR && inputRAR)
            {
                anim.Play("Glootle_idle");
            }
            //Right leg left
            else if (inputLAR && !inputA)
            {
                anim.Play("Glootle_Rightfootleft");
                StartCoroutine(MoveRightfootLeft(legWait));
                facingleft = true;
            }
            //Right leg Right
            else if (inputRAR && !inputD)
            {
                Debug.Log("RAR leg move");
                anim.Play("Glootle_RightfootRight");
                StartCoroutine(MoveRightfootRight(legWait));
                facingleft = false;
            }
            
            
            if (inputS && inputDAR)
            {
                BodyBalanceScript.targetRotation = 50;
                HeadBalanceScript.targetRotation = 50;
                 leftlegbalance.targetRotation =  50;
                rightlegbalance.targetRotation =  50;
                
            }
            else if (!inputS && !inputDAR)
            {
                BodyBalanceScript.targetRotation = 0;
                HeadBalanceScript.targetRotation = 0;
                 leftlegbalance.targetRotation = 0;
                rightlegbalance.targetRotation = 0;
            }
            
            
            
        }

        
        //This is one player
        if (Legtype == false)
        {
            onground = Physics2D.OverlapCircle(playerpos.position, positionradius, ground);
            if (onground == true && Input.GetKeyDown(KeyCode.W) || onground == true && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jump * Vector2.up);
            }
            
            if (inputS || inputUAR)
            {
                BodyBalanceScript.targetRotation = 50;
                HeadBalanceScript.targetRotation = 50;
                leftlegbalance.targetRotation =  -200;
                rightlegbalance.targetRotation = -200;
                
            }
            else if (!inputS || !inputUAR)
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
        rightLegRB.AddForce(Vector2.right * (speed * 1000));
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator MoveLeftfootRight(float seconds)
    {
        leftLegRB.AddForce(Vector2.right * (speed * 1000));
        yield return new WaitForSeconds(seconds);
    }
    
    IEnumerator MoveRightfootLeft(float seconds)
    {
        rightLegRB.AddForce(Vector2.left * (speed * 1000));
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator MoveLeftfootleft(float seconds)
    {
        leftLegRB.AddForce(Vector2.left * (speed * 1000));
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator MoveRight(float seconds)
    {
        leftLegRB.AddForce(Vector2.right * (speed * 1000));
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.right * (speed * 1000));
    }

    IEnumerator MoveLeft(float seconds)
    {
        rightLegRB.AddForce(Vector2.left * (speed * 1000));
        yield return new WaitForSeconds(seconds);
        leftLegRB.AddForce(Vector2.left * (speed * 1000));
    }
}
