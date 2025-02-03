using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance_script : MonoBehaviour
{
    
    public float targetRotation;
    public Rigidbody2D rb;
    public SpriteRenderer sp;
    public float force;
    public Balance_script BalanceScript;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sp = gameObject.GetComponent<SpriteRenderer>();
        BalanceScript = gameObject.GetComponent<Balance_script>();
    }

    // Update is called once per frame
    void Update()
    {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.deltaTime));

            if (Movement_script.Mainmovement.facingleft == true)
            {
                sp.flipX = true;
            }
            else
            {
                sp.flipX = false;
            }
     
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        Obstacles_script obstacles = other.gameObject.GetComponent<Obstacles_script>();
        if (obstacles != null)
        {
            onbalance_script.bodydisengaged = true;
            Destroy(other.gameObject);
        }
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        DEATH_script death = other.gameObject.GetComponent<DEATH_script>();
        if (death != null)
        {
            onbalance_script.gameover = true;
        }
    }
}
