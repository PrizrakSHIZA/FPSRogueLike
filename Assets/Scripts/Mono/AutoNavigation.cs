using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoNavigation : MonoBehaviour
{
    [Header("Settings")]
    public bool OnlyPlayer;
    public float radius;
    public float force;
    public float maxvelocity;

    Rigidbody rbody;

    private void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var target in hitColliders)
        {
            if (OnlyPlayer && target.gameObject.tag == "Player")
            {
                //Make target point a bit higher
                Vector3 targetpos = target.transform.position;
                targetpos.y += 0.5f;
                //Calculate direction
                Vector3 direction = (targetpos - transform.position).normalized;
                rbody.AddForce(direction * force);

                if (rbody.velocity.magnitude > maxvelocity)
                {
                    rbody.velocity = rbody.velocity.normalized * maxvelocity;
                }

                /*
                 * Dont go if already pass
                if (Vector3.Dot(rigidbody.velocity, direction) < 0)
                    return;
                */

                Debug.DrawRay(transform.position, rbody.velocity, Color.cyan);
                Debug.DrawRay(transform.position, -direction, Color.red);
            }
        }
    }
}
