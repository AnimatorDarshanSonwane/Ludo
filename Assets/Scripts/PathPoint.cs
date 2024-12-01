using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    public PathObjectsParent PathObjectsParent;

    List<PlayerPieces> playerPiecesList = new List<PlayerPieces>();

    int spriteLayer = 1;  

    private void Start()
    {
        PathObjectsParent = GetComponentInParent<PathObjectsParent>();
    }

    public void AddPlayerPieces(PlayerPieces playerPiece_) { 
    
        playerPiecesList.Add(playerPiece_);
        RescaleAndRepositionAllPlayerPiece();
    }

    public void RemovePlayerPieces(PlayerPieces playerPiece_)
    {

        if (playerPiecesList.Contains(playerPiece_))
        {
            playerPiecesList.Remove(playerPiece_);
            RescaleAndRepositionAllPlayerPiece();
        }
    }

    public  void RescaleAndRepositionAllPlayerPiece()
    {
        int playersCount = playerPiecesList.Count;
        bool isOdd = (playersCount % 2) != 0;
        int extent = playersCount / 2;

        for (int i = 0; i < playersCount; i++)
        {
            float scale = PathObjectsParent.scale[playersCount - 1];
            playerPiecesList[i].transform.localScale = new Vector3(scale, scale, 1f);

            // Calculating position offset
            float offset = (i - extent) * PathObjectsParent.positionsDifference[playersCount - 1];

            // Adjust for odd number of pieces
            if (!isOdd && i >= extent)
            {
                offset += PathObjectsParent.positionsDifference[playersCount - 1] / 2;
            }

            playerPiecesList[i].transform.position = new Vector3(transform.position.x + offset, transform.position.y, 0f);
        }

        for (int i = 0; i <playerPiecesList.Count; i++) {

            playerPiecesList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = spriteLayer;
            spriteLayer++;
        }

    }

}
