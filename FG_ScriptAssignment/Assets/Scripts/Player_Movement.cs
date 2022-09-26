using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] ActivePlayerManager manager;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpHeight = 50f;
    [SerializeField] PlayerTurn playerTurn;

    bool isJumping;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }
    void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (IsPlayerTurn)
        {
            MovePlayer();
            JumpPlayer();
        }
        MovePlayer();
        JumpPlayer();
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue,0,zValue);        
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.AddRelativeForce(Vector3.up * jumpHeight);                      

            //Debug.Log("I am jumping");            
        }
    }
    
    
    
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
}
    

