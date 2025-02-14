using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onbalance_script : MonoBehaviour
{
    public Balance_script balULL, balLLL, balbody, balURL, balLRL, balhead;
    public Animator glootleani;
    public bool backup = true, gravityfix;
    public static bool bodydisengaged = false, gameover = false, firsttime = true, Invi = false;
    public float stuntimer = 5, gameovertimer = 5, timesup, invitimer;
    public Movement_script MovementScript;
    
    public GameObject body;
    public TextMeshPro milestext, highscoretext, Timertext;
    public float miles;
    public static float EndTimer, Thehighscore, savedHS;
    // Update is called once per frame
    
    
    public void Start()
    {
        // PlayerPrefs.SetInt("highscore",0);
        EndTimer = 0;
        gameovertimer = 5;
        bodydisengaged = false;
        timesup = 3;
        gameover = false;
        invitimer = 2.5f;
    }
    

    void FixedUpdate()
    {
        // Debug.Log(Thehighscore);
        // Debug.Log(savedHS);
        // Debug.Log(EndTimer);
        // Debug.Log(firsttime);
        
        //tracks and displays: meters and high score
        miles = (float)(Mathf.Round(body.transform.position.x * 10) / 10.0);
        milestext.text = "Miles: " + miles+ "m";

        if (gameover == false)
        {
            EndTimer += Time.deltaTime;
        }
        Timertext.text = "Time: " + EndTimer.ToString("F");
        highscoretext.text = "High Score: " + Thehighscore.ToString("F");
        
        
        // if (EndTimer < PlayerPrefs.GetFloat("highscore", Thehighscore))
        // {
        //     PlayerPrefs.SetFloat("highscore", Thehighscore);
        // }
        //
        
        // if (miles > PlayerPrefs.GetFloat("highscore", 0))
        // {
        //     PlayerPrefs.SetFloat("highscore", miles);
        // }
        
        if (gameover == true)
        {
            glootleani.Play("Glootle_perish");
            MovementScript.enabled = false;
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
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            bodydisengaged = false;
            gameover = false;
            gameovertimer = 5;
        }

        if (bodydisengaged == true && gameover == false)
        {
            glootleani.Play("Glootle_stunned");
            balhead.enabled = false;
            balURL.enabled = false;
            balLLL.enabled = false;
            balbody.enabled = false;
            balLRL.enabled = false;
            balULL.enabled = false;
            backup = false;
            MovementScript.speed = 0;
            MovementScript.enabled = false;
        }
        
        if (stuntimer <= 0)
        {
            backup = true;
            bodydisengaged = false;
            balhead.enabled =true;
            balbody.enabled =true;
            balURL.enabled = true;
            balLLL.enabled = true;
            balLRL.enabled = true;
            balULL.enabled = true;
            MovementScript.rb.gravityScale = 18;
            MovementScript.headrb.gravityScale = 18;
            MovementScript.speed = 0.03f;
            stuntimer = 3;
            MovementScript.enabled = true;
            gravityfix = true;
            Invi = true;
        }

        if (gravityfix == true)
        {
            timesup -= .1f;
        }

        if (Invi == true)
        {
            invitimer -= Time.deltaTime;
        }
       
        if (invitimer <= 0)
        {
            Invi = false;
            invitimer = 2.5f;
        }
        
        if (timesup <= 0)
        {
            MovementScript.rb.gravityScale = 1;
            MovementScript.headrb.gravityScale = 1;
            timesup = 3;
            gravityfix = false;
        }
        
        if (backup == false)
        {
            stuntimer -= Time.deltaTime;
        }
        
        
    }

    public void timerHighscore()
    {
        if (firsttime)
        {
            savedHS = Thehighscore;
            highscoretext.text = $"High Score: {Thehighscore.ToString("F")}";
            PlayerPrefs.SetFloat("Highscore",savedHS);
            firsttime = false;
        }
        else if (EndTimer < savedHS)
        {
            if (savedHS < timesup)
            {
                savedHS = Thehighscore;
            }
            highscoretext.text = $"High Score: {Thehighscore.ToString("F")}";
            PlayerPrefs.SetFloat("Highscore", savedHS);
        }
        else
        {
            highscoretext.text = $"High Score: {Thehighscore.ToString("F")}";
            PlayerPrefs.SetFloat("highscore", savedHS);
        }
    }

    

}
