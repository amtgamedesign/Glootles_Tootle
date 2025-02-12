using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Animator anim;
    
    public void StartGame()
    {
        anim.Play("GlootleCrash");
        StartCoroutine(Wait());
        Debug.Log("waiting");
        SceneManager.LoadScene("Gameplay");
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
    }
    
}
