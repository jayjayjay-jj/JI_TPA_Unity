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

    public void fading()
    {
        fadeScreen(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void fadeScreen (int screen)
    {
        screenIndex = screen;
        animator.SetTrigger("FadeOut");
    }

    public void clickButton()
    {
        startButtonAudio.enabled = true;
        fading();
    }

    public void gamePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
