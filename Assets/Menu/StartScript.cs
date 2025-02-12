using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Animator anim;
    
    public void StartGame()
    {
        Debug.Log("waiting");
        StartCoroutine(Wait());
        StartCoroutine(ShakeScreen());
        anim.Play("GlootleCrash");
        //StartCoroutine(Wait());
        //SceneManager.LoadScene("Gameplay");
    }

    public IEnumerator ShakeScreen()
    {
        yield return new WaitForSeconds(1f);
        anim.Play("Shake");
    }
    
    
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Gameplay");

    }
    
}
