using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(GameSettings.CurrentLevel);
        while (gameLevel.progress < 1)
        {
            slider.value = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
