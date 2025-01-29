using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow_script : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothtime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetposition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetposition, smoothtime);

        
    //     transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);
     }
}
