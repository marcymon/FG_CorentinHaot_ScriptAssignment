using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerInput : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float walkingSpeed;

    void Update()
    {
        if (manager.PlayerCanPlay())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.transform.Translate(currentPlayer.transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.GetComponent<ActivePlayerWeapon>().ShootLaser();
            }
        }
    }
}
