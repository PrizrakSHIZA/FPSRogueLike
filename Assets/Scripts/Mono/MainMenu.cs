using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject StarGameMenu;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartLevel(string level)
    {
        GameSettings.CurrentLevel = level;
        SceneManager.LoadScene("LoadingScreen");
    }

    public void StartGame()
    {
        Main.SetActive(false);
        StarGameMenu.SetActive(true);
    }

    public void Back()
    {
        Main.SetActive(true);
        StarGameMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
