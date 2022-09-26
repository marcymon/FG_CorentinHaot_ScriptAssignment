using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerWeapon : MonoBehaviour
{
    [SerializeField] private float weaponDamage;
    [SerializeField] private Color rayColor;
    [SerializeField] private Transform weaponBarrel;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private MeshRenderer weaponRenderer;
    [SerializeField] private GameObject[] weaponMeshes;

    private WeaponPickup currentWeapon;
    private float rayDelay;

    private void Start()
    {
        foreach (GameObject weaponMesh in weaponMeshes)
        {
            weaponMesh.SetActive(false);
        }
    }

    public void AssignWeapon(WeaponPickup pickedUpWeapon)
    {
        currentWeapon = pickedUpWeapon;
        foreach (GameObject weaponMesh in weaponMeshes)
        {
            bool activeWeapon = weaponMesh.name == pickedUpWeapon.GetWeaponName();
            weaponMesh.SetActive(activeWeapon);
        }
    }

    void Update()
    {
        if (rayDelay > 0)
        {
            rayDelay -= Time.deltaTime;
            if (rayDelay <= 0)
            {
                lineRenderer.enabled = false;
            }
        }
    }

    public float GetDamage()
    {
        if (currentWeapon != null)
        {
            return currentWeapon.GetDamage();
        }

        return weaponDamage;
    }

    public Color GetColor()
    {
        if (currentWeapon != null)
        {
            return currentWeapon.GetColor();
        }

        return rayColor;
    }

    public void ShootLaser()
    {
        RaycastHit result;
        bool thereWasHit = Physics.Raycast(weaponBarrel.position, transform.forward, out result, Mathf.Infinity);

        lineRenderer.startColor = GetColor();
        lineRenderer.endColor = GetColor();
        lineRenderer.SetPosition(0, weaponBarrel.position);
        lineRenderer.enabled = true;
        rayDelay = 0.25f;

        if (thereWasHit)
        {
            ActivePlayerHealth activePlayerHealth = result.collider.GetComponent<ActivePlayerHealth>();
            if (activePlayerHealth != null)
            {
                activePlayerHealth.TakeDamage(GetDamage());
            }
            lineRenderer.SetPosition(1, result.point);
        }
        else
        {
            lineRenderer.SetPosition(1, weaponBarrel.position + transform.forward * 50);
        }
    }
}
