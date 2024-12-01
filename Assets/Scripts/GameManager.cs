using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public RollingDice rolledDice;
    public int numberOfStepsToMove;
    public bool CanMove;

    List<PathPoint> playerOnPathPointList = new List<PathPoint>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddPathPoint(PathPoint pathPoint_)
    {
        playerOnPathPointList.Add(pathPoint_);
    }

    public void RemovePathPoint(PathPoint pathPoint_)
    {
        if (playerOnPathPointList.Contains(pathPoint_))
        {
            playerOnPathPointList.Remove(pathPoint_);
        }
        else
        {
            Debug.Log("Path not found : Point was removed");
        }
    }

}
