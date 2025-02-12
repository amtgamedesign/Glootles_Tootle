using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Animator glootleAnim;
    public Animator titleAnim;

    public void Start()
    {
        titleAnim.Play("TitleGoop");
    }
    
    public void StartGame()
    {
        StartCoroutine(ShakeScreen());
        glootleAnim.Play("GlootleCrash");
        StartCoroutine(Wait());
    }

    public IEnumerator ShakeScreen()
    {
        yield return new WaitForSeconds(2.5f);
        titleAnim.Play("Shake");
    }
    
    
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Gameplay");

    }
    
}
