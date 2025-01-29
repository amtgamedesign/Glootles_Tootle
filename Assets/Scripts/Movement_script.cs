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
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float legWait = .5f;
    // Start is called before the first frame update
    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal input axis, so this is both a d and arrow keys
        // swap control from axes to instead key presses
        // instead i dont want to check the axis, i want to know if a has been pressed or d
        // and then move a leg accordingly
        // similarly
        // check if right and left arrow have been pressed, and move the other leg accordingly
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if(Input.GetAxis("Horizontal") > 0)
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


    IEnumerator MoveRight(float seconds)
    {
        leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.right * (-speed * 1000) * Time.deltaTime);
    }

    IEnumerator MoveLeft(float seconds)
    {
        rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftLegRB.AddForce(Vector2.left * (-speed * 1000) * Time.deltaTime);
    }
}
