using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDetection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> weaponsList = new List<GameObject>();
    
    public void pickWeapon(GameObject weapon)
    {
        weaponsList.Add(weapon);
    }

    public void removeWeapon(GameObject weapon)
    {
        weaponsList.Remove(weapon);
    }
}
