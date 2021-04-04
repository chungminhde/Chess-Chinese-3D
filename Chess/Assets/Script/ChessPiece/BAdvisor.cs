using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAdvisor : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (gridPoint.y == 10)
        {
            locations.Add(new Vector2Int(4, 9));
        }
        if (gridPoint.y == 9)
        {
            locations.Add(new Vector2Int(5, 8));
            locations.Add(new Vector2Int(3, 8));
            locations.Add(new Vector2Int(5, 10));
            locations.Add(new Vector2Int(3, 10));
        }
        if (gridPoint.y == 8)
        {
            locations.Add(new Vector2Int(4, 9));
        }

        return locations;
    }
}
