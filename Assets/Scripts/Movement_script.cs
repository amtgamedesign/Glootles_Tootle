using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public GameObject leftLeg;
    public GameObject rightLeg;
   public Rigidbody2D leftLegRB;
    public Rigidbody2D rightLegRB;
    
    Animator anim;
    [SerializeField] float speed = 2f;
    //[SerializeField] float jumpHeight = 2f;
    [SerializeField] float legWait = .5f;
    // Start is called before the first frame update


    public bool Legtype;
    
    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Legtype = false;
        }
        
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Legtype = true;
        }
        
        // horizontal input axis, so this is both a d and arrow keys
        // swap control from axes to instead key presses
        // instead i dont want to check the axis, i want to know if a has been pressed or d
        // and then move a leg accordingly
        // similarly
        // check if right and left arrow have been pressed, and move the other leg accordingly



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
