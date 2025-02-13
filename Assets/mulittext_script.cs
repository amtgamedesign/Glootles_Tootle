using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class mulittext_script : MonoBehaviour
{
    public Animator ani;
    public int randomnumber, min, max;
    
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = Random.Range(min,max);
    }

    // Update is called once per frame
    void Update()
    {

        if (randomnumber == 1)
        {
            ani.Play("Crash");
            Invoke("OnDestroy", 1f);
        }
        else if (randomnumber == 2)
        {
            ani.Play("Smack");
            Invoke("OnDestroy", 1f);
        }
        else if (randomnumber == 3)
        {
            ani.Play("Boom");
            Invoke("OnDestroy", 1f);
        }
        
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
