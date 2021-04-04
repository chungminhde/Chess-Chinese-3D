using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPawn : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (gridPoint.y < 6 && gridPoint.x > 0)
        {
            locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y));
        }
        if (gridPoint.y < 6 && gridPoint.x < 8)
        {
            locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y));
        }
        locations.Add(new Vector2Int(gridPoint.x, gridPoint.y - 1));
        return locations;
    }
}
