using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Gameobjects")]
    public GameObject Bullet;
    public GameObject BulletEmitter;
    [Header("Settings")]
    [Range(0f,10f)]
    public float spread;
    public float bulletForce;
    public bool onclick = false;
    public float firePause;

    bool allowfire = true;
    Animation anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();    
    }

    void Update()
    {
        if (onclick)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && allowfire)
            {
                anim.Stop();
                anim.Play("FireAnim_TestPistol");
                StartCoroutine("Fire");
            }
        }
        else
        {
            if (Input.GetAxis("Fire1") > 0 && allowfire)
            {
                anim.Stop();
                anim.Play("FireAnim_TestPistol");
                StartCoroutine("Fire");
            }
        }
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
        yield return new WaitForSeconds(firePause);
        allowfire = true;
    }
}
