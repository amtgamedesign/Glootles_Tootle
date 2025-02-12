using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_sprite_script : MonoBehaviour
{
    public SpriteRenderer SR;
    public List<Sprite> carcolors;
    public int randomnumber, min, max;
    
    // Start is called before the first frame update
    void Start()
    {
        randomnumber = Random.Range(min,max);
    }

    // Update is called once per frame
    void Update()
    {
        SR.sprite = carcolors[randomnumber];
    }
}
