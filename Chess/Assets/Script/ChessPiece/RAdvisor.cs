using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAdvisor : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if (gridPoint.y == 1 )
        {
            locations.Add(new Vector2Int(4, 2));
        }
        if (gridPoint.y == 2)
        {
            locations.Add(new Vector2Int(5, 3));
            locations.Add(new Vector2Int(3, 3));
            locations.Add(new Vector2Int(5, 1));
            locations.Add(new Vector2Int(3, 1));
        }
        if (gridPoint.y == 3 )
        {
            locations.Add(new Vector2Int(4, 2));
        }
        
        return locations;
    }
}
