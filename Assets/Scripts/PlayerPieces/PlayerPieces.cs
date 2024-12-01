using System.Collections;
using UnityEngine;

public class PlayerPieces : MonoBehaviour
{
    public bool isReady;
    //public bool canMove;
    public bool isMove;
    public int numberOfStepsAlreadyMoved;

    public PathObjectsParent pathsParent;
    public PathPoint previousPathPoint;
    public PathPoint currentPathPoint;

    Coroutine moveSteps_Coroutine;
    private void Awake()
    {
        pathsParent = FindObjectOfType<PathObjectsParent>();
    }

    public void MoveSteps(PathPoint[] pathPointsToMoveOn) { 
        moveSteps_Coroutine = StartCoroutine(MoveStepsEnum(pathPointsToMoveOn));
    }

    public void MakePlayerReadyToMove(PathPoint[] pathPointsToMoveOn)
    {
        isReady = true;
        transform.position = pathPointsToMoveOn[0].transform.position;
        numberOfStepsAlreadyMoved = 1;
        previousPathPoint = pathPointsToMoveOn[0];
        currentPathPoint = pathPointsToMoveOn[0];
        currentPathPoint.AddPlayerPieces(this);
        GameManager.Instance.AddPathPoint(currentPathPoint);
        GameManager.Instance.CanMove = true;
        
    }

    IEnumerator MoveStepsEnum(PathPoint[] pathPointsToMoveOn)
    {
        yield return new WaitForSeconds(0.25f);

        int numOfStepsToMove = GameManager.Instance.numberOfStepsToMove;

        if (GameManager.Instance.CanMove)
        {
            previousPathPoint.RescaleAndRepositionAllPlayerPiece();
            for (int i = numberOfStepsAlreadyMoved; i < (numOfStepsToMove + numberOfStepsAlreadyMoved ); i++)
            {
                if (IsPathPointAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn))
                {
                    transform.position = pathPointsToMoveOn[i].transform.position;
                    yield return new WaitForSeconds(0.25f);
                }
                
            }
        }

        if (IsPathPointAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn)){
            numberOfStepsAlreadyMoved += numOfStepsToMove;
            GameManager.Instance.numberOfStepsToMove = 0;

            GameManager.Instance.RemovePathPoint(previousPathPoint);
            previousPathPoint.RemovePlayerPieces(this);
            currentPathPoint= pathPointsToMoveOn[numberOfStepsAlreadyMoved-1];
            currentPathPoint.AddPlayerPieces(this);
            GameManager.Instance.AddPathPoint(currentPathPoint);
            previousPathPoint= currentPathPoint;
        }
        
        if (moveSteps_Coroutine != null) {
            StopCoroutine(moveSteps_Coroutine);
        }
    }

    bool IsPathPointAvailableToMove(int numOfStepsToMove_, int numberOfStepsAlreadyMove_, PathPoint[] pathPointsToMoveOn ) {
   
        int leftNumOfPathPoints = pathPointsToMoveOn.Length - numberOfStepsAlreadyMove_;

        if (leftNumOfPathPoints >= numOfStepsToMove_) { 
            return true;
        }
        return false;
    }

}
