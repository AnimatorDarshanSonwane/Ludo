using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerPiece : PlayerPieces
{
    RollingDice redPlayerRollingDice;
    private void Start()
    {
        redPlayerRollingDice = GetComponentInParent<RedPlayersHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (!isReady)
        {
            if (GameManager.Instance.rolledDice == redPlayerRollingDice && GameManager.Instance.numberOfStepsToMove == 6)
            {
                MakePlayerReadyToMove(pathsParent.redPathPoints);
                GameManager.Instance.numberOfStepsToMove = 0;
                return;
            }

        }

        if (GameManager.Instance.rolledDice == redPlayerRollingDice && isReady)
        {
            canMove = true;
        MoveSteps(pathsParent.redPathPoints);
        }

    }
}
