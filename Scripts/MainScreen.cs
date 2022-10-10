using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{

    public AudioSource startButtonAudio;

    public void gamePlay ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        startButtonAudio.enabled = false;
    }

    public void clickButton()
    {
        startButtonAudio.enabled = true;
    }
}
