using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPiece : PlayerPieces
{
    RollingDice bluePlayerRollingDice;
    private void Start()
    {
        bluePlayerRollingDice = GetComponentInParent<BluePlayersHome>().rollingDice;
    }

    private void OnMouseDown()
    {
        if (!isReady) {
            if (GameManager.Instance.rolledDice == bluePlayerRollingDice && GameManager.Instance.numberOfStepsToMove == 6)
            {
                MakePlayerReadyToMove(pathsParent.bluePathPoints);
                GameManager.Instance.numberOfStepsToMove = 0;
                return;
            }

        }

        if (GameManager.Instance.rolledDice == bluePlayerRollingDice && isReady && GameManager.Instance.CanMove)
        {

        GameManager.Instance.CanMove = false;
        MoveSteps(pathsParent.bluePathPoints);
        }

    }
}
