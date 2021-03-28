using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry {

    private static Geometry _instance;

    public static Geometry Instance()
    {
        if (_instance == null)
        {
            _instance = new Geometry();
        }

        return _instance;
    }

    static public void CreateBoard ()
    {
        // col
        for(float i = -3.5f; i <= 3.5; i += 0.875f)
        {
            //row 
            for(float j = 1.0f; j<= 10.0f; j++)
            {
                
            }
        }
    }


    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        
        float x = -3.5f + 0.875f * (float)gridPoint.x;
        float z = 1.0f * gridPoint.y;
        return new Vector3(x, 0, z);
    }

    static public Vector2Int GridPoint(int col, int row)
    {
        return new Vector2Int(col, row);
    }

    static public Vector2Int GridFromPoint(Vector3 point)
    {
        //int col = ((int)(point.x / 0.875f)) + 4;
        //Thêm 0.075 fix bug độ nhạy
        int col = ((int)(point.x / 0.8f)) + 4;

        //int row = Mathf.FloorToInt(point.z);
        //thêm 0.1 fix bug độ nhạy
        int row = Mathf.FloorToInt(point.z / 0.9f)  ;
        return new Vector2Int(col, row);
    }

}
