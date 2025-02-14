using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_script : MonoBehaviour
{
    public Transform tr;
    public SpriteRenderer Sr;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        Reverse_script reverse = other.gameObject.GetComponent<Reverse_script>();
        if (reverse != null)
        {
            Sr.transform.localScale = new Vector3(tr.localScale.x * -1,tr.localScale.y,tr.localScale.z);
            xfloat *= -1;
            yfloat *= -1;
        }
    }
}
