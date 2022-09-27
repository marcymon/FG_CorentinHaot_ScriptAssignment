using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerInput : MonoBehaviour
{
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    [SerializeField] private float walkingSpeed = 2f;
    [SerializeField] private float pitchClamp = 90f;
    [SerializeField] private ActivePlayerManager manager;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Start()
    {
        Cursor.visible = false;
    }
    //[SerializeField] float jumpHeight = 5f;

    //bool isJumping;



    void Update()
    {
        PlayerCanMove();
        ReadRotationInput();          
    }

    void ReadRotationInput()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);


        ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        currentPlayer.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        currentPlayer.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        characterCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //characterCamera.transform.localEulerAngles = new Vector3(0.0f, yaw, 0.0f);


    }


    void PlayerCanMove()
    {
        if (manager.PlayerCanPlay())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.transform.Translate(transform.right * walkingSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.transform.Translate(transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.GetComponent<ActivePlayerWeapon>().ShootLaser();
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
            
            
                /*if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                ActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.rb.AddRelativeForce(Vector3.up * jumpHeight);             
            }
            */
        }
    }
   
}
