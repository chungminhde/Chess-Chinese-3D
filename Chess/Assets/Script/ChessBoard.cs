using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour {
    //Set up red chess board
    public RPawn RPawnPrefab;
    public RKing RKingPrefab;
    public RAdvisor RAdvisorPrefab;
    public RElephant RElephantPrefab;
    public RHorse RHorsePrefab;
    public RRook RRookPrefab;
    public RCannon RCannonPrefab;

    //Set up black chess board
    public BPawn BPawnPrefab;
    public BKing BKingPrefab;
    public BAdvisor BAdvisorPrefab;
    public BElephant BElephantPrefab;
    public BHorse BHorsePrefab;
    public BRook BRookPrefab;
    public BCannon BCannonPrefab;

    public Material defaultMaterial;
    public Material selectedMaterial;

    // Use this for initialization

    void Start () {
        GenerateChessBoard();

    }
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = selectedMaterial;
    }
    void GenerateChessBoard()
    {
        // Red Pawn
        for(int i = 0; i < RPawnPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(RPawnPrefab.config.PosY[i], RPawnPrefab.config.PosX));
            Instantiate(RPawnPrefab, position,Quaternion.identity);
        }
        // Red Cannon
        for (int i = 0; i < RCannonPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(RCannonPrefab.config.PosY[i], RCannonPrefab.config.PosX));
            Instantiate(RCannonPrefab, position, Quaternion.identity);
        }
        // Red Advisor
        for (int i = 0; i < RAdvisorPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(RAdvisorPrefab.config.PosY[i], RAdvisorPrefab.config.PosX));
            Instantiate(RAdvisorPrefab, position, Quaternion.identity);
        }
        // Red Elephant
        for (int i = 0; i < RElephantPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(RElephantPrefab.config.PosY[i], RElephantPrefab.config.PosX));
            Instantiate(RElephantPrefab, position, Quaternion.identity);
        }
        // Red horse
        for (int i = 0; i < RHorsePrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(RHorsePrefab.config.PosY[i], RHorsePrefab.config.PosX));
            Instantiate(RHorsePrefab, position, Quaternion.identity);
        }
        // Red Rook
        for (int i = 0; i < RRookPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(RRookPrefab.config.PosY[i], RRookPrefab.config.PosX));
            Instantiate(RRookPrefab, position, Quaternion.identity);
        }
        // Red King
        for (int i = 0; i < RKingPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(RKingPrefab.config.PosY[i], RKingPrefab.config.PosX));
            Instantiate(RKingPrefab, position, Quaternion.identity);
        }
        // Black Pawn
        for (int i = 0; i < BPawnPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(BPawnPrefab.config.PosY[i], BPawnPrefab.config.PosX));
            Instantiate(BPawnPrefab, position, Quaternion.identity);
        }
        // Black Cannon
        for (int i = 0; i < BCannonPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(BCannonPrefab.config.PosY[i], BCannonPrefab.config.PosX));
            Instantiate(BCannonPrefab, position, Quaternion.identity);
        }
        // Black Advisor
        for (int i = 0; i < BAdvisorPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(BAdvisorPrefab.config.PosY[i], BAdvisorPrefab.config.PosX));
            Instantiate(BAdvisorPrefab, position, Quaternion.identity);
        }
        // Black Elephant
        for (int i = 0; i < BElephantPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(BElephantPrefab.config.PosY[i], BElephantPrefab.config.PosX));
            Instantiate(BElephantPrefab, position, Quaternion.identity);
        }
        // Black Horse
        for (int i = 0; i < BHorsePrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(BHorsePrefab.config.PosY[i], BHorsePrefab.config.PosX));
            Instantiate(BHorsePrefab, position, Quaternion.identity);
        }
        // Black Rook
        for (int i = 0; i < BRookPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(BRookPrefab.config.PosY[i], BRookPrefab.config.PosX));
            Instantiate(BRookPrefab, position, Quaternion.identity);
        }
        //Black King
        for (int i = 0; i < BKingPrefab.config.PosY.Length; i++)
        {
            var position = Geometry.PointFromGrid(new Vector2Int(BKingPrefab.config.PosY[i], BKingPrefab.config.PosX));
            Instantiate(BKingPrefab, position, Quaternion.identity);
        }
    }
}
