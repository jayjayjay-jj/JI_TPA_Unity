using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{

    public Weapon weapon;
    public Rigidbody rigidBody;
    public BoxCollider boxCollider;
    public Transform player, WeaponContainer;

    public float weaponRange;

    public bool pickedUp;

    private void Start()
    {
        if(!pickedUp)
        {
            weapon.enabled = false;
            rigidBody.isKinematic = false;
            boxCollider.isTrigger = false;
        }

        if (pickedUp)
        {
            weapon.enabled = true;
            rigidBody.isKinematic = true;
            boxCollider.isTrigger = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 weaponDistance = player.position - transform.position;
        if(!pickedUp && weaponDistance.magnitude <= weaponRange && Input.GetKeyDown(KeyCode.E))
        {
            pickWeapon();
        }
    }

    private void pickWeapon()
    {
        pickedUp = true;

        transform.SetParent(WeaponContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //rigidBody doesn't move
        rigidBody.isKinematic = true;
        boxCollider.isTrigger = true;

        weapon.enabled = true;
        PlayerMovement.isHoldingWeapon = true;
    }
}
