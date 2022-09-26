using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Color rayColor;
    [SerializeField] private string weaponName;

    private void OnTriggerEnter(Collider other)
    {
        ActivePlayerWeapon playerWeapon = other.GetComponent<ActivePlayerWeapon>();
        if (playerWeapon != null)
        {
            playerWeapon.AssignWeapon(this);
            gameObject.SetActive(false);
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    public Color GetColor()
    {
        return rayColor;
    }

    public string GetWeaponName()
    {
        return weaponName;
    }
}
