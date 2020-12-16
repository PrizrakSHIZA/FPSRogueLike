using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameSettings.CurrentLevel = "MainMenu";
            SceneManager.LoadScene("LoadingScreen");
        }
    }
}
