using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinScreen : MonoBehaviour
{
    [SerializeField] ParticleSystem winParticles1;
    [SerializeField] ParticleSystem winParticles2;
    [SerializeField] ParticleSystem winParticles3;
    
    public GameObject winText;
    public GameObject reloadButton;
    public GameObject playerMoving;

    bool playerWin;
    bool played;

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
        if (playerWin == true && !played)
        {
            winParticles1.Play();
            winParticles2.Play();
            winParticles3.Play();
            winText.SetActive(true);
            reloadButton.SetActive(true);
            playerMoving.SetActive(false);
            Cursor.visible = true;
            played = true;
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
