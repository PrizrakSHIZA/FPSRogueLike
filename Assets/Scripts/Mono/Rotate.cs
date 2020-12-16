using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation;
    public bool random;

    private void Start()
    {
        if (random)
        {
            rotation.x = Random.Range(0f, 100f);
            rotation.y = Random.Range(0f, 100f);
            rotation.z = Random.Range(0f, 100f);
        }
    }
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
