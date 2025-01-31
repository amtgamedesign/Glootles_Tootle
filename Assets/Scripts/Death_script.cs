using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATH_script : MonoBehaviour
{
    public Rigidbody2D RB;
    public float xfloat, yfloat;

    // Update is called once per frame
    void FixedUpdate()
    {
        RB.velocity = new Vector2(xfloat, yfloat);
    }
}
