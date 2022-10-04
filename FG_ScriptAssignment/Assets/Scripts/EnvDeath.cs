using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvDeath : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    
    public GameObject checkPoint;

    Vector3 lastCheckpoint;

    void Start()
    {
        lastCheckpoint = checkPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("I bumped");
            transform.position = checkPoint.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
             lastCheckpoint = this.gameObject.transform.position;
        }
    }
}
