using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onbalance_script : MonoBehaviour
{
   // public Balance_script BalanceScript;

    public Balance_script balULL, balLLL, balbody, balURR, balLRR, balhead;
    // Start is called before the first frame update
    void Start()
    {
        // BalanceScript = gameObject.GetComponent<Balance_script>();
        // BalanceScript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     if (BalanceScript.enabled == false)
        //     {
        //         BalanceScript.enabled = true;
        //     }
        // }

        if (balhead.enabled == false | balURR.enabled == false | balLRR.enabled == false | balULL.enabled == false | balLLL.enabled == false | balbody.enabled == false)
        {
            balhead.enabled = false;
            balURR.enabled = false;
            balLLL.enabled = false;
            balbody.enabled = false;
            balLRR.enabled = false;
            balULL.enabled = false;
            
        }
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        Balance_script bal = other.gameObject.GetComponent<Balance_script>();
        if (bal != null)
        {
            Balance_script.stunned = true;
        }
    }
}
