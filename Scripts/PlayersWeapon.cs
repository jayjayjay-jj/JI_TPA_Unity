using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersWeapon : MonoBehaviour
{
    [SerializeField]
    private WeaponDetection detection;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            detection.pickWeapon(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            detection.removeWeapon(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            
        }
    }
}
