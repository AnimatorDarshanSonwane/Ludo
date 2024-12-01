using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObjectsParent : MonoBehaviour
{
    [SerializeField] public PathPoint[] commonPathPoints;
    [SerializeField] public PathPoint[] yellowPathPoints;
    [SerializeField] public PathPoint[] greenPathPoints;
    [SerializeField] public PathPoint[] bluePathPoints;
    [SerializeField] public PathPoint[] redPathPoints;

    [Header("Scale and Positions Differece")]
    public float[] scale;
    public float[] positionsDifference;
    public Vector2 boxSize = new Vector2(0.79f, 0.8416667f); 

}
