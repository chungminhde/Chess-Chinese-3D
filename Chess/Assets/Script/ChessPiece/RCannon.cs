using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCannon : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        foreach (Vector2Int dir in RookDirections)
        {
            for (int i = 1; i < 11; i++)
            {
                Vector2Int nextGridPoint = new Vector2Int(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
                if (GameManager.instance.PieceAtGrid(nextGridPoint))
                {
                    for (int j = i; j < 11 - i; j++)
                    {
                        Vector2Int nextGridPoint2 = new Vector2Int(gridPoint.x + (i +j)* dir.x, gridPoint.y + (i +j)* dir.y);
                        if (GameManager.instance.PieceAtGrid(nextGridPoint2))
                        {
                            locations.Add(nextGridPoint);
                            break;
                        }
                    }
                }
                locations.Add(nextGridPoint);
            }
        }
        return locations;
    }
   
}
