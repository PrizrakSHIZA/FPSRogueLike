using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Level0 : MonoBehaviour
{
    TextMeshProUGUI timer;

    void Start()
    {
        timer = GameObject.Find("MainCanvas/Timer").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (GameObject.Find("Player"))
        {
            TimeSpan time = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
            timer.text = time.ToString("mm':'ss");
        }
    }
}
