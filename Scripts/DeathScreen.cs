using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public AudioSource buttonAudio;

    void Start()
    {
        buttonAudio.enabled = false;
    }

    public void clickedButton()
    {
        buttonAudio.enabled = true;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Debug.Log("Quitting game hihi");
        Application.Quit();
    }
}
