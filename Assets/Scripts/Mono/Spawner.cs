using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject Enemy;
    public float everysec;
    [Range(0f, 1f)]
    public float SpawnChance = 1f;
    public float random;
    public bool fromstart = false;
    
    [Header("Difficulty with time")]
    public float IncreaseChanceEvery = 60f;
    [Range(0f, 1f)]
    public float IncreaseValue = 0.01f;

    bool canspawn = true;
    Vector3 position;
    ParticleSystem PS;

    private void Start()
    {
        PS = gameObject.GetComponentInChildren<ParticleSystem>();
        position = transform.position;
        position.y += 2f;
        if (fromstart)
            StartCoroutine(Spawn());
    }

    void Update()
    {
        if (canspawn)
            StartCoroutine(Spawn());         
    }

    IEnumerator Spawn()
    {
        canspawn = false;
        float chance = Random.Range(0f, 1f);
        if (chance <= SpawnChance + Mathf.FloorToInt(Time.timeSinceLevelLoad / IncreaseChanceEvery) * IncreaseValue)
        {
            PS.Play();
            Instantiate(Enemy, position, transform.rotation);
        }
        yield return new WaitForSeconds(everysec + Random.Range(-random, random));
        canspawn = true;
    }
}
