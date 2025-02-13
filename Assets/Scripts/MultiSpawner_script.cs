using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpawner_script : MonoBehaviour
{
    public GameObject cars, jets, tanks, blasters;
    public float spawntimer;
    public int randomobject;
    
    // Start is called before the first frame update
    void Start()
    {
        spawntimer = Random.Range(0f, 3f);
        randomobject = Random.Range(1, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawntimer -= Time.deltaTime;
        if (spawntimer < 0)
        {
            randomobject = Random.Range(1, 6);
            //Cars
            if (randomobject == 1)
            {
                spawntimer = Random.Range(4f, 5f);
                Instantiate(cars,new Vector3(125.1463f,transform.position.y - 5.45f,transform.position.z),Quaternion.identity);
            }

            //Jet
            if (randomobject == 2)
            {
                spawntimer = Random.Range(3f, 4f);
                Instantiate(jets,new Vector3(126,2 + Random.Range(-4f,3f),transform.position.z),Quaternion.identity);
            }

            if (randomobject == 3)
            {
                spawntimer = Random.Range(3f, 4f);
                Instantiate(jets,new Vector3(126,2 + Random.Range(-4f,3f),transform.position.z),Quaternion.identity);
            }
            
            //Tank
            if (randomobject == 4)
            {
                spawntimer = Random.Range(5f, 6f);
                Instantiate(tanks,new Vector3(124.7026f,transform.position.y - 5.91f,transform.position.z),Quaternion.identity);
             
            }

            //Blasters
            if (randomobject == 5)
            {
                spawntimer = Random.Range(3f, 4f);
                Instantiate(blasters,new Vector3(126,5.30f,transform.position.z),Quaternion.identity);
      
            }
        }
    }
}
