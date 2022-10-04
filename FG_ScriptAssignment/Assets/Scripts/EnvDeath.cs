using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvDeath : MonoBehaviour
{
    [SerializeField] private ActivePlayerManager manager;
    
    public GameObject checkPoint;
    
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
        //ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("I bumped");
            transform.position = checkPoint.transform.position;
        }
    }
}
