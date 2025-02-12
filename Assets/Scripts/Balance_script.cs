using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance_script : MonoBehaviour
{
    
    public float targetRotation;
    public Rigidbody2D rb;
    public float force;
    public Balance_script BalanceScript;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        BalanceScript = gameObject.GetComponent<Balance_script>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.deltaTime));
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        stun_script stunScript = other.gameObject.GetComponent<stun_script>();
        if (stunScript != null)
        {
            if (onbalance_script.Invi == false)
            {
                onbalance_script.bodydisengaged = true;
            }
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (onbalance_script.Invi == false)
        {
            stuntrigger_script stuntriggerScript = other.gameObject.GetComponent<stuntrigger_script>();
            if (stuntriggerScript != null)
            {
                onbalance_script.bodydisengaged = true;
            }

            Shot_script shotScript = other.gameObject.GetComponent<Shot_script>();
            if (shotScript != null)
            {
                onbalance_script.bodydisengaged = true;
            }
        }

    }
}
