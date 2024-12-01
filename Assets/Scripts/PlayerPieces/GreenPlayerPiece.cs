using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerPiece : PlayerPieces
{
    RollingDice greenPlayerRollingDice;

    private void Start()
    {
        greenPlayerRollingDice = GetComponentInParent<GreenPlayersHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (!isReady)
        {
            if (GameManager.Instance.rolledDice == greenPlayerRollingDice && GameManager.Instance.numberOfStepsToMove == 6)
            {
                MakePlayerReadyToMove(pathsParent.greenPathPoints);
                GameManager.Instance.numberOfStepsToMove = 0;
                return;
            }

        }
        if (GameManager.Instance.rolledDice == greenPlayerRollingDice && isReady)
        {
            canMove = true;
            MoveSteps(pathsParent.greenPathPoints);
        }

    }

}
