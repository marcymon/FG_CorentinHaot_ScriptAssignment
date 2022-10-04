using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolines : MonoBehaviour
{
    [SerializeField] float powerHeight = 5f;
    [SerializeField] private ActivePlayerManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * powerHeight);
        }
    }
}
