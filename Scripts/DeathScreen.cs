using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
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
