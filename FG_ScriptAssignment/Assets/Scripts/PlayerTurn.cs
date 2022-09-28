using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{

    public bool isJumping;
    private int playerIndex;

    public void SetPlayerTurn(int index)
    {
        playerIndex = index;
    }
    
    public bool IsPlayerTurn()
    {
        return TurnManager.GetInstance().IsItPlayerTurn(playerIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground Check"))
        {
            isJumping = false;
            Debug.Log("I can jump");
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground Check"))
        {
            isJumping = true;
            Debug.Log("I cannot jump");
        }
    }
}
