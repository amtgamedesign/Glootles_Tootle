using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Animator glootleAnim;
    public Animator titleAnim;
    public Animator crashAnim;

    public void Start()
    {
        titleAnim.Play("TitleGoop");
    }
    
    public void StartGame()
    {
        StartCoroutine(ShakeScreen());
        StartCoroutine(Crash());
        glootleAnim.Play("GlootleCrash");
        StartCoroutine(Wait());
    }

    public IEnumerator ShakeScreen()
    {
        yield return new WaitForSeconds(2.5f);
        titleAnim.Play("Shake");
    }

    public IEnumerator Crash()
    {
        yield return new WaitForSeconds(2f);
        crashAnim.Play("CrashSound");
    }
    
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Gameplay");

    }
    
}
