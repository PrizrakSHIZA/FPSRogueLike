using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    public float damage;
    public float lifetime;
    [Header("Particles")]
    public ParticleSystem PS_Walls;
    public ParticleSystem PS_OnLife;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(PS_OnLife, collision.contacts[0].point, Quaternion.identity);
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Instantiate(PS_OnLife, collision.contacts[0].point, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(damage);
        }
        else
        {
            Instantiate(PS_Walls, collision.contacts[0].point, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
