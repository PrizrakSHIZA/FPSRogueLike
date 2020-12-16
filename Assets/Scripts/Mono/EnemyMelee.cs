using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : MonoBehaviour
{
    [Header("Settings")]
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public float damage = 10f;
    public float attackSpeed = 5f;
    [HideInInspector]
    public bool onattack = false;


    NavMeshAgent agent;
    Animation anim;
    GameObject playertarget;
    bool allowfire = true, candamage = false;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animation>();
        anim.Play("Walk");
        anim["Attack"].speed = attackSpeed;
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, lookRadius);
        foreach (var target in hitColliders)
        {
            if (target.gameObject.tag == "Player")
            {
                if (onattack)
                {
                    Vector3 direction = (target.transform.position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed / 100f);
                }

                if (Vector3.Distance(target.transform.position, transform.position) > attackRadius)
                {
                    candamage = false;
                    if (!onattack)
                    {
                        anim.Play("Walk");
                        agent.SetDestination(target.transform.position);
                    }
                }
                else
                {
                    candamage = true;
                    if (allowfire && !onattack)
                    {
                        anim.Stop();
                        anim.Play("Attack");
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Attack()
    {
        if (candamage && playertarget)
        {
            playertarget.GetComponent<PlayerHP>().TakeDamage(damage);
            playertarget = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playertarget = other.gameObject;
        }
    }
}
