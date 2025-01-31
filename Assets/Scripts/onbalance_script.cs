using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onbalance_script : MonoBehaviour
{
    public Balance_script balULL, balLLL, balbody, balURL, balLRL, balhead;
    public bool backup = true;
    public static bool bodydisengaged = false, gameover = false;
    public float timer = 5, gameovertimer = 5;
    public Movement_script MovementScript;

    // Update is called once per frame
    void Update()
    {
        if (gameover == true)
        {
            balhead.enabled = false;
            balURL.enabled = false;
            balLLL.enabled = false;
            balbody.enabled = false;
            balLRL.enabled = false;
            balULL.enabled = false;
            MovementScript.speed = 0;
            gameovertimer -= Time.deltaTime;
        }

        if (gameovertimer <= 0)
        {
            SceneManager.LoadScene("Gameplay");
            bodydisengaged = false;
            gameover = false;
            gameovertimer = 5;
        }

        if (bodydisengaged == true)
        {
            balhead.enabled = false;
            balURL.enabled = false;
            balLLL.enabled = false;
            balbody.enabled = false;
            balLRL.enabled = false;
            balULL.enabled = false;
            backup = false;
            MovementScript.speed = 0;
        }
        
        if (timer <= 0)
        {
            balhead.enabled =true;
            balURL.enabled = true;
            balLLL.enabled = true;
            balbody.enabled =true;
            balLRL.enabled = true;
            balULL.enabled = true;

            bodydisengaged = false;
            timer = 5;
            backup = true;
            MovementScript.speed = 1;
        }

        if (backup == false)
        {
            timer -= Time.deltaTime;
        }
        
    }

    
}
