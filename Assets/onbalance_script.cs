using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onbalance_script : MonoBehaviour
{
    public Balance_script BalanceScript;
    // Start is called before the first frame update
    void Start()
    {
        BalanceScript = gameObject.GetComponent<Balance_script>();
        BalanceScript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (BalanceScript.enabled == false)
            {
                BalanceScript.enabled = true;
            }
        } 
    }
}
