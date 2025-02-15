using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Room_script : MonoBehaviour
{
    public string desiredscene, Thescene, currentscenename;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Balance_script balanceScript = other.gameObject.GetComponent<Balance_script>();
        if (balanceScript != null)
        {
            SceneManager.LoadScene(desiredscene);
        }

    }

    public void OnMouseDown()
    {
        if (currentscenename == Thescene)
        {
            SceneManager.LoadScene(desiredscene);
        }
    }
}
