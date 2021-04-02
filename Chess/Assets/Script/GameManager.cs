using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static ChessBoard board;

    public static GameObject RPawn;
    public static GameObject RCannon;
    public static GameObject RRook;
    public static GameObject RHorse;
    public static GameObject RElephant;
    public static GameObject RAdvisor;
    public static GameObject RKing;

    public static GameObject BPawn;
    public static GameObject BCannon;
    public static GameObject BRook;
    public static GameObject BHorse;
    public static GameObject BElephant;
    public static GameObject BAdvisor;
    public static GameObject BKing;

    private GameObject[,] pieces;
    public Player currentPlayer;
    public Player otherPlayer;

    void Awake()
    {
        instance = this;
    }

    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {   
        if (gridPoint.x > 10 || gridPoint.y > 8)
        {
            return null;
        }
        return pieces[gridPoint.x, gridPoint.y];
    }
    public void SelectPiece(GameObject piece)
    {
        board.SelectPiece(piece);
    }
    public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }
    private void Start()
    {
        pieces = new GameObject[10, 10];
    }
}
