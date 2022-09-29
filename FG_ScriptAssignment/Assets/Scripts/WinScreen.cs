using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinScreen : MonoBehaviour
{
    public GameObject winText;
    public GameObject reloadButton;
    public GameObject playerMoving;
    
    bool playerWin;
    
    void Start()
    {
        playerWin = false;
        winText.SetActive(false);
        reloadButton.SetActive(false);
        playerMoving.SetActive(true);
        Cursor.visible = false;
        
    }

   
    public void Update()
    {        
        if (playerWin == true)
        {
            winText.SetActive(true);
            reloadButton.SetActive(true);
            playerMoving.SetActive(false);
            Cursor.visible = true;
        }
        
    }   
    public void OnCollisionEnter(Collision collision)
    {
        PlayerWin(collision);
    }

    private void PlayerWin(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerWin = true;
            Debug.Log(collision.gameObject.name + " win !");
        }
    }
}
