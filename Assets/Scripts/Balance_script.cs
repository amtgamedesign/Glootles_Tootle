using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance_script : MonoBehaviour
{
    public float targetRotation;
    public Rigidbody2D rb;
    public float force;
    public Balance_script BalanceScript;
    
    public static float timer = 5;
    public static bool stunned;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        BalanceScript = gameObject.GetComponent<Balance_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned == false)
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.deltaTime));
        }

        if (stunned == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 5;
            stunned = false;
        }
        
     
    }
}
