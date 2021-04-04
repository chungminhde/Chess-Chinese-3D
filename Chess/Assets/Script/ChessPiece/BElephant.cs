using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BElephant : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (gridPoint.y == 10)
        {
            locations.Add(new Vector2Int(4, 8));
        }
        if (gridPoint.y == 8)
        {
            locations.Add(new Vector2Int(2, 10));
            locations.Add(new Vector2Int(6, 10));
            locations.Add(new Vector2Int(2, 6));
            locations.Add(new Vector2Int(6, 6));
        }
        if (gridPoint.y == 6)
        {
            locations.Add(new Vector2Int(4, 8));
        }

        return locations;
    }
}
