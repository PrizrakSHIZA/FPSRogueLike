using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Main settings")]
    public GameObject weaponHandler;
    public int inventorySlots;

    [Header("Starting weapons")]
    public GameObject[] startWeapons;

    GameObject[] inventory;
    int currentselect = 0;
    GameObject temp;
    void Start()
    {
        inventory = new GameObject[inventorySlots];
        for (int i = 0; i < startWeapons.Length ; i++)
        {
            GiveWeapon(i, startWeapons[i]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActive(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActive(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActive(2);
        }
    }

    void SetActive(int slot)
    {
        if (inventory[slot])
        {
            currentselect = slot;
            foreach (Transform child in weaponHandler.transform)
            {
                Destroy(child.gameObject);
            }
            temp = Instantiate(inventory[slot]);
            temp.transform.parent = weaponHandler.transform;
            temp.transform.localPosition = new Vector3(0, -0.623f, -0.634f);
            temp.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void GiveWeapon(int i, GameObject weapon)
    {
        inventory[i] = weapon;
    }

    public void DeleteWeapon()
    { 
    
    }
}
