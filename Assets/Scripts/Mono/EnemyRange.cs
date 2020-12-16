using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRange : MonoBehaviour
{
    [Header("Weapon")]
    public Transform Weapon;
    public GameObject Bullet;
    public GameObject BulletEmitter;
    public float spread = 1f;
    public float bulletForce = 1f;

    [Header("Settings")]
    public float lookRadius = 10f;
    public LayerMask visionblock;
    public float attackRadius = 2f;
    public float attackPause = 5f;


    NavMeshAgent agent;
    Animation anim;
    bool allowfire = true;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        //anim = gameObject.GetComponent<Animation>();
        //anim.Play("Walk");
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, lookRadius);
        foreach (var target in hitColliders)
        {
            if (target.gameObject.tag == "Player")
            {
                if (Vector3.Distance(target.transform.position, transform.position) > attackRadius)
                {
                    //anim.Play("Walk");
                    agent.SetDestination(target.transform.position);
                }
                else
                {
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, target.transform.position - transform.position, out hit, lookRadius, visionblock))
                    {
                        if (hit.collider.gameObject.tag == "Player")
                        {
                            agent.SetDestination(transform.position);

                            //Weapon up angle
                            //Weapon.LookAt(target.transform);
                            Vector3 relativePos = target.transform.position - Weapon.position; 
                            Quaternion rotation = Quaternion.LookRotation(relativePos);
                            Weapon.rotation = rotation;

                            //Enemy rotation
                            Vector3 direction = (target.transform.position - transform.position).normalized;
                            Quaternion lookRotation = Quaternion.LookRotation(direction);
                            lookRotation.x = 0;
                            lookRotation.z = 0;
                            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed / 100f);
                            
                            if (allowfire)
                            {
                                //anim.Stop();
                                //anim.Play("Attack");
                                StartCoroutine(Fire());
                            }
                        }
                        else
                        {
                            //anim.Play("Walk");
                            agent.SetDestination(target.transform.position);
                        }
                    }

                    Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.green);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    IEnumerator Fire()
    {
        allowfire = false;
        GameObject temp = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation);

        Vector3 spreadVector = Vector3.zero;
        spreadVector.x += Random.Range(-spread, spread);
        spreadVector.y += Random.Range(-spread, spread);
        temp.transform.Rotate(spreadVector);
        temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * bulletForce * 1000);
        Destroy(temp, 10f);
        yield return new WaitForSeconds(attackPause);
        allowfire = true;
    }
}
