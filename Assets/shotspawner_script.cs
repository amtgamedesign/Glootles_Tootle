using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class shotspawner_script : MonoBehaviour
{
    private float shottimer;
    public Animator spawnerani;
    public int shottimerrestart, animationstart;
    public GameObject shot;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shottimer = Random.Range(1,10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shottimer -= Time.deltaTime;

        if (shottimer < animationstart)
        {
            spawnerani.Play("");
        }
        
        
        if (shottimer <= 0)
        {
            shottimer = shottimerrestart;
            Instantiate(shot, transform.position, quaternion.identity);
        }
    }
}
