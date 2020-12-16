using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void MainMenu()
    {
        GameSettings.CurrentLevel = "MainMenu";
        SceneManager.LoadScene("LoadingScreen");
    }
}
