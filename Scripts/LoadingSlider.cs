using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSlider : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        StartCoroutine(updateLoad());
    }

    IEnumerator updateLoad()
    {
        float loadIncrement = 0;
        AsyncOperation loading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while(!loading.isDone)
        {
            loadIncrement = Mathf.Clamp01(loading.progress / 0.9f);
            slider.value = loadIncrement;

            yield return null;
        }
    }
}
