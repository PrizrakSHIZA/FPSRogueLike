using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float health = 100f;
    public ParticleSystem PS_Death;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            PlayDeath();
        }
    }
    
    void PlayDeath()
    {
        Instantiate(PS_Death, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
