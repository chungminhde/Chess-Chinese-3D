using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RElephant : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (gridPoint.y == 1 && gridPoint.x == 2)
        {
            locations.Add(new Vector2Int(4, 3));
            locations.Add(new Vector2Int(0, 3));
        }
        if (gridPoint.y == 1 && gridPoint.x == 6)
        {
            locations.Add(new Vector2Int(4, 3));
            locations.Add(new Vector2Int(8, 3));
        }
        if (gridPoint.y == 3 && gridPoint.x == 4)
        {
            locations.Add(new Vector2Int(2, 5));
            locations.Add(new Vector2Int(6, 5));
            locations.Add(new Vector2Int(2, 1));
            locations.Add(new Vector2Int(6, 1));
        }
        if (gridPoint.y == 3 && gridPoint.x == 0)
        {
            locations.Add(new Vector2Int(2, 5));
            locations.Add(new Vector2Int(2, 1));
        }
        if (gridPoint.y == 5 && gridPoint.x == 2)
        {
            locations.Add(new Vector2Int(0, 3));
            locations.Add(new Vector2Int(4, 3));
        }
        if (gridPoint.y == 5 && gridPoint.x == 6)
        {
            locations.Add(new Vector2Int(8, 3));
            locations.Add(new Vector2Int(4, 3));
        }
        if (gridPoint.y == 3 && gridPoint.x == 8)
        {
            locations.Add(new Vector2Int(6, 1));
            locations.Add(new Vector2Int(6, 5));
        }

            return locations;
    }
}
