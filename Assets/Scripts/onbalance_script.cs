using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onbalance_script : MonoBehaviour
{
    public Balance_script balULL, balLLL, balbody, balURL, balLRL, balhead;
    public bool backup = true;
    public float timer = 5;


    // Update is called once per frame
    void Update()
    {

        if (balhead.enabled == false | balURL.enabled == false | balLRL.enabled == false | balULL.enabled == false | balLLL.enabled == false | balbody.enabled == false)
        {
            balhead.enabled = false;
            balURL.enabled = false;
            balLLL.enabled = false;
            balbody.enabled = false;
            balLRL.enabled = false;
            balULL.enabled = false;
            backup = false;
        }
        
        if (timer <= 0)
        {
            balhead.enabled =true;
            balURL.enabled = true;
            balLLL.enabled = true;
            balbody.enabled =true;
            balLRL.enabled = true;
            balULL.enabled = true;

            timer = 5;
            backup = true;
        }

        if (backup == false)
        {
            timer -= Time.deltaTime;
        }
        
    }

    
}
