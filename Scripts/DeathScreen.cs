using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public AudioSource buttonAudio;
    public Animator animator;

    void Start()
    {
        buttonAudio.enabled = false;
    }

    public void mainMenu()
    {
        buttonAudio.enabled = false;
        buttonAudio.enabled = true;
        StartCoroutine(delay());
    }

    public void quit()
    {
        buttonAudio.enabled = false;
        buttonAudio.enabled = true;
        Debug.Log("Quitting game hihi");
        //fadeScreen();
        Application.Quit();
    }

    IEnumerator delay()
    {
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
