using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_script : MonoBehaviour
{
    public Rigidbody2D RB;
    public float xfloat, yfloat;

    public int ydestroy, xdestroy;
    // Start is called before the first frame update
    void Start()
    {
      //  transform.Rotate(0,0,90);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RB.velocity = new Vector2(xfloat, yfloat);
    }

    public void Update()
    {
        if (gameObject.transform.position.x <= xdestroy || gameObject.transform.position.y <= ydestroy)
        {
            Destroy(gameObject);
        }
    }
}
