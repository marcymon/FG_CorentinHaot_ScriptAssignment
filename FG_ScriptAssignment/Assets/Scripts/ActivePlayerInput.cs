using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerInput : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    [SerializeField] private float horizontalSpeed = 2f;
    [SerializeField] private float walkingSpeed;
    //[SerializeField] float jumpHeight = 5f;

    //bool isJumping;

    

    void Update()
    {
        PlayerCanMove();
          
    }
/*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground Check")
        {
            isJumping = false;
            //Debug.Log("I can jump");
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground Check")
        {
            isJumping = true;
            //Debug.Log("I cannot jump");
        }
    }
  */

    void PlayerCanMove()
    {
        if (manager.PlayerCanPlay())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
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

            /*if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.rb.AddRelativeForce(Vector3.up * jumpHeight);             
            }
            */
        }
    }
   
}
