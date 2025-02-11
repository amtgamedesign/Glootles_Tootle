using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_script : MonoBehaviour
{
    public Animator shotani;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        shotani.Play("Shot_animation");
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        floor_script floorScript = other.gameObject.GetComponent<floor_script>();
        if (floorScript != null)
        {
            Destroy(gameObject);
        }
    }
}
