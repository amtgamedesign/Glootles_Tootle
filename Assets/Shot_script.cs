using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_script : MonoBehaviour
{
    public float anidone;
    public Animator shotani;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        shotani.Play("Shot_animation");
        anidone -= Time.deltaTime;
        if (anidone <= 0)
        {
            Destroy(gameObject);
        }
    }
}
