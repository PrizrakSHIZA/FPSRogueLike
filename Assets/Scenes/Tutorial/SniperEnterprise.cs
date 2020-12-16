using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnterprise : MonoBehaviour
{
    public GameObject player;
    public GameObject animcamera;
    public GameObject bullet;


    private void OnTriggerEnter(Collider other)
    {
        player.SetActive(false);
        animcamera.SetActive(true);
        gameObject.GetComponent<Animation>().Play();
    }

    public void BacktoNormal()
    {
        player.SetActive(true);
        animcamera.SetActive(false);
        Destroy(this);
    }

    public void ShootBullet()
    {
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 4000f);
    }
}
