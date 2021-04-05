using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHorse : Piece {

    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        List<Vector2Int> posibleMove = new List<Vector2Int>();

        posibleMove.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y + 2));
        posibleMove.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y + 2));

        posibleMove.Add(new Vector2Int(gridPoint.x + 2, gridPoint.y + 1));
        posibleMove.Add(new Vector2Int(gridPoint.x - 2, gridPoint.y + 1));

        posibleMove.Add(new Vector2Int(gridPoint.x + 2, gridPoint.y - 1));
        posibleMove.Add(new Vector2Int(gridPoint.x - 2, gridPoint.y - 1));

        posibleMove.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y - 2));
        posibleMove.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y - 2));

        foreach (var move in posibleMove)
        {
            if (!IsBlocked(gridPoint, move))
            {
                locations.Add(move);
            }
        }

        return locations;
    }

    bool IsBlocked(Vector2Int gridPoint, Vector2Int newPos)
    {
        int yIntermediate;
        int xIntermediate;

        bool horizontalMov = (Math.Abs(gridPoint.y - newPos.y) == 1) && (Math.Abs(gridPoint.x - newPos.x) == 2);
        bool verticalMov = (Math.Abs(gridPoint.y - newPos.y) == 2) && (Math.Abs(gridPoint.x - newPos.x) == 1);
        if (horizontalMov)
        {
            yIntermediate = gridPoint.y;
            xIntermediate = newPos.x + ((gridPoint.x - newPos.x) / 2);
        }
        else
        {
            yIntermediate = newPos.y + ((gridPoint.y - newPos.y) / 2);
            xIntermediate = gridPoint.x;
        }
        Vector2Int gridIntermediate = new Vector2Int(xIntermediate, yIntermediate);
        return (horizontalMov || verticalMov) && GameManager.instance.PieceAtGrid(gridIntermediate);
    }
}
