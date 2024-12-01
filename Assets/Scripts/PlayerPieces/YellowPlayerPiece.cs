using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerPiece : PlayerPieces
{
    RollingDice yellowPlayerRollingDice;
    private void Start()
    {
        yellowPlayerRollingDice = GetComponentInParent<YellowPlayersHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (!isReady)
        {
            if (GameManager.Instance.rolledDice == yellowPlayerRollingDice && GameManager.Instance.numberOfStepsToMove == 6)
            {
                MakePlayerReadyToMove(pathsParent.yellowPathPoints);
                GameManager.Instance.numberOfStepsToMove = 0;
                return;
            }

        }
        if (GameManager.Instance.rolledDice == yellowPlayerRollingDice && isReady && GameManager.Instance.CanMove)
        { 
        MoveSteps(pathsParent.yellowPathPoints);
        }

    }
}
