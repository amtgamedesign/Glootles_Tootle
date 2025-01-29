using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance_script : MonoBehaviour
{
    public float targetRotation;
    public Rigidbody2D rb;
    public float force;
    public Balance_script BalanceScript;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        BalanceScript = gameObject.GetComponent<Balance_script>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.P))
        {
            BalanceScript.enabled = false;
        }
    }
}
