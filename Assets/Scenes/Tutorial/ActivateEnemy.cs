using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public bool onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (!onExit)
        {
            Enemy.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (onExit)
        {
            Enemy.SetActive(true);
        }
    }
}
