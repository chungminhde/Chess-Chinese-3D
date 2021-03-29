using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour {

    public RPawn pawnPrefab;
    public BHorse horsePrefab;

	// Use this for initialization

	void Start () {
        GenerateChessBoard();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateChessBoard()
    {
        for(int i = 0; i < pawnPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int( pawnPrefab.config.PosY[i], pawnPrefab.config.PosX));
            Instantiate(pawnPrefab, position,Quaternion.identity);
        }
        for (int i = 0; i < horsePrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(horsePrefab.config.PosY[i], horsePrefab.config.PosX));
            Instantiate(horsePrefab, position, Quaternion.identity);
        }
    }
}
