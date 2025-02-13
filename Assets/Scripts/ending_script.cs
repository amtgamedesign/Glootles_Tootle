using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ending_script : MonoBehaviour
{
    public TextMeshPro highscoretext, Timertext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timertext.text = "Time: " + onbalance_script.EndTimer.ToString("F");
        highscoretext.text = "High Score: " + onbalance_script.Thehighscore.ToString("F");
    }
}
