using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivePlayerManager : MonoBehaviour
{
    [SerializeField] private ActivePlayer player1;
    [SerializeField] private ActivePlayer player2;
    [SerializeField] private float maxTimePerTurn;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private Image clock;
    [SerializeField] private TextMeshProUGUI seconds;

    private ActivePlayer currentPlayer;
    private float currentTurnTime;
    private float currentDelay;

    void Start()
    {
        player1.AssignManager(this);
        player2.AssignManager(this);

        currentPlayer = player1;
    }

    private void Update()
    {
        if (currentDelay <= 0)
        {
            currentTurnTime += Time.deltaTime;

            if (currentTurnTime >= maxTimePerTurn)
            {
                ChangeTurn();
                ResetTimers();
            }
            UpdateTimeVisuals();
        }
        else 
        {
            currentDelay -= Time.deltaTime;
        }
    }

    public bool PlayerCanPlay()
    {
        return currentDelay <= 0;
    }

    public ActivePlayer GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void ChangeTurn()
    {
        if (player1 == currentPlayer)
        {
            currentPlayer = player2;
        }
        else if (player2 == currentPlayer)
        {
            currentPlayer = player1;
        }

        ResetTimers();
        UpdateTimeVisuals();
    }

    private void ResetTimers()
    {
        currentTurnTime = 0;
        currentDelay = timeBetweenTurns;
    }

    private void UpdateTimeVisuals()
    {
        clock.fillAmount = 1 - (currentTurnTime / maxTimePerTurn);
        seconds.text = Mathf.RoundToInt(maxTimePerTurn - currentTurnTime).ToString();
    }
}
