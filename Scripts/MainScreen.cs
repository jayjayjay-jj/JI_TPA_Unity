using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{

    public AudioSource startButtonAudio;
    public Animator animator;

    private int screenIndex;

    // Start is called before the first frame update
    void Start()
    {
        startButtonAudio.enabled = false;
    }

    public void fadeScreen ()
    {
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void clickButton()
    {
        startButtonAudio.enabled = true;
        fadeScreen();
    }

    public void gamePlay()
    {
        fadeScreen();
    }
}
