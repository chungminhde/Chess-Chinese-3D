using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RKing : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (gridPoint.y == 1)
        {   
            if (gridPoint.x > 3)
            {
                locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y));
            }
            if (gridPoint.x < 5)
            {
                locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y));
            }
            locations.Add(new Vector2Int(gridPoint.x, gridPoint.y + 1));
        }
        if (gridPoint.y == 2)
        {
            if (gridPoint.x > 3)
            {
                locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y));
            }
            if (gridPoint.x < 5)
            {
                locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y));
            }
            locations.Add(new Vector2Int(gridPoint.x, gridPoint.y + 1));
            locations.Add(new Vector2Int(gridPoint.x, gridPoint.y - 1));
        }
        if (gridPoint.y == 3)
        {
            if (gridPoint.x > 3)
            {
                locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y));
            }
            if (gridPoint.x < 5)
            {
                locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y));
            }
            locations.Add(new Vector2Int(gridPoint.x, gridPoint.y - 1));
        }

        return locations;
    }
}
