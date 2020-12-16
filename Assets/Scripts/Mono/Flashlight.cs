using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.GetComponent<Light>().intensity = 1 - gameObject.GetComponent<Light>().intensity;
        }
    }
}
