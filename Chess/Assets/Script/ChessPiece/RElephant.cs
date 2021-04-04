using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RElephant : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (gridPoint.y == 1)
        {
            locations.Add(new Vector2Int(4, 3));
        }
        if (gridPoint.y == 3)
        {
            locations.Add(new Vector2Int(2, 5));
            locations.Add(new Vector2Int(6, 5));
            locations.Add(new Vector2Int(2, 1));
            locations.Add(new Vector2Int(6, 1));
        }
        if (gridPoint.y == 5)
        {
            locations.Add(new Vector2Int(4, 3));
        }

        return locations;
    }
}
