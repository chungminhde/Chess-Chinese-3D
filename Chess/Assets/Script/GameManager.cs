using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ChessBoard board;

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

    private GameObject[,] pieces;
    private List<GameObject> movedPawns;
    private GameObject currentSelectPiece;

    private Player red;
    private Player black;
    public Player currentPlayer;
    public Player otherPlayer;

    public Player HumanSide;
    public Player AISide;

    public Action<bool> DeselectEvent;

    public bool isGameOver = false;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InitialSetup();
    }

    private void InitialSetup()
    {
        pieces = new GameObject[9, 11];

        red = new Player("red", true);
        black = new Player("black", false);

        currentPlayer = red;
        otherPlayer = black;

        HumanSide = red;
        AISide = HumanSide == red ? black : red;
        GenerateChessBoard();
    }

    public void AddPiece(GameObject prefab, Player player, int col, int row)
    {
        GameObject pieceObject = board.AddPiece(prefab, col, row);
        player.pieces.Add(pieceObject);
        pieces[col, row] = pieceObject;
    }

    public void SelectPieceAtGrid(Vector2Int gridPoint)
    {
        GameObject selectedPiece = pieces[gridPoint.x, gridPoint.y];
        if (selectedPiece)
        {
            board.SelectPiece(selectedPiece);
        }
    }

    public List<Vector2Int> MovesForPiece(GameObject pieceObject)
    {
        Piece piece = pieceObject.GetComponent<Piece>();
        Vector2Int gridPoint = GridForPiece(pieceObject);
        List<Vector2Int> locations = piece.MoveLocations(gridPoint);

        // filter out offboard locations
        // x = 0 -> 8
        // y = 1 -> 10
        locations.RemoveAll(gp => gp.x < 0 || gp.x > 8 || gp.y < 1 || gp.y > 10);

        // filter out locations with friendly piece
        locations.RemoveAll(gp => FriendlyPieceAt(gp));

        return locations;
    }

    public void Move(GameObject piece, Vector2Int gridPoint)
    {
        Piece pieceComponent = piece.GetComponent<Piece>();


        Vector2Int startGridPoint = GridForPiece(piece);
        pieces[startGridPoint.x, startGridPoint.y] = null;
        pieces[gridPoint.x, gridPoint.y] = piece;
        board.MovePiece(piece, gridPoint);
    }

    public void PawnMoved(GameObject pawn)
    {
        movedPawns.Add(pawn);
    }

    public bool HasPawnMoved(GameObject pawn)
    {
        return movedPawns.Contains(pawn);
    }

    public void CapturePieceAt(Vector2Int gridPoint)
    {
        GameObject pieceToCapture = PieceAtGrid(gridPoint);
        if (pieceToCapture.GetComponent<Piece>().config.Name == ChessName.BKing || pieceToCapture.GetComponent<Piece>().config.Name == ChessName.RKing)
        {
            Debug.Log(currentPlayer.name + " wins!");
            UIManager.instance.ShowUI(true);
            UIManager.instance.SetWinnerText(currentPlayer.name + " wins!");
            isGameOver = true;
            //Destroy(board.GetComponent<TileSelector>());
            //Destroy(board.GetComponent<MoveSelector>());
        }
        currentPlayer.capturedPieces.Add(pieceToCapture);
        otherPlayer.pieces.Remove(pieceToCapture);
        pieces[gridPoint.x, gridPoint.y] = null;
        Destroy(pieceToCapture);
    }

    public void SelectPiece(GameObject piece)
    {
        currentSelectPiece = piece;
        board.SelectPiece(piece);
    }

    public void DeselectPiece(GameObject piece)
    {
        currentSelectPiece = null;
        board.DeselectPiece(piece);
    }

    public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }

    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
     //   Debug.Log(gridPoint);
        // x = 0 -> 8
        // y = 1 -> 10
        if (gridPoint.x > 8 || gridPoint.y > 10 || gridPoint.x < 0 || gridPoint.y < 1)
        {
            return null;
        }
       // Debug.LogError(gridPoint);
        return pieces[gridPoint.x, gridPoint.y];
    }

    public Vector2Int GridForPiece(GameObject piece)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j < 11; j++)
            {
                if (pieces[i, j] == piece)
                {
                    return new Vector2Int(i, j);
                }
            }
        }

        return new Vector2Int(-1, -1);
    }

    public bool FriendlyPieceAt(Vector2Int gridPoint)
    {
        GameObject piece = PieceAtGrid(gridPoint);

        if (piece == null)
        {
            return false;
        }

        if (otherPlayer.pieces.Contains(piece))
        {
            return false;
        }

        return true;
    }

    public void NextPlayer()
    {
        Player tempPlayer = currentPlayer;
        currentPlayer = otherPlayer;
        otherPlayer = tempPlayer;

    }

    public bool IsAITurn()
    {
        return currentPlayer == AISide;
    }

    public void DoAIMove()
    {

        /* 
         insert MiniMax here
         Minimax should return 
         - Piece : which piece should move
         - Vector2Int : grid to move
          */
        var listPieces = GetPlayerPieces(currentPlayer);
        var idx = UnityEngine.Random.Range(0, listPieces.Count);
       
        var movingPiece = listPieces[idx];
        var moveLocations = MovesForPiece(movingPiece);
        var moveIdx = UnityEngine.Random.Range(0, moveLocations.Count);
        var gridPoint = moveLocations[moveIdx];
        if(GameManager.instance.PieceAtGrid(gridPoint) == null)
        {
            
            GameManager.instance.Move(movingPiece, gridPoint);
        }
        else
        {
            GameManager.instance.CapturePieceAt(gridPoint);
            GameManager.instance.Move(movingPiece, gridPoint);
        }
        GameManager.instance.NextPlayer();
    }

    private List<GameObject> GetPlayerPieces(Player player)
    {
        return player.pieces;
    }

    void GenerateChessBoard()
    {
        //Red Pawn
        for (int i = 0; i < RPawnPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(RPawnPrefab.gameObject, RPawnPrefab.config.PosY[i], RPawnPrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RPawnPrefab.config.PosY[i], RPawnPrefab.config.PosX] = pieceObject;

        }
        // Red Cannon
        for (int i = 0; i < RCannonPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(RCannonPrefab.gameObject, RCannonPrefab.config.PosY[i], RCannonPrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RCannonPrefab.config.PosY[i], RCannonPrefab.config.PosX] = pieceObject;
        }
        // Red Advisor
        for (int i = 0; i < RAdvisorPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(RAdvisorPrefab.gameObject, RAdvisorPrefab.config.PosY[i], RAdvisorPrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RAdvisorPrefab.config.PosY[i], RAdvisorPrefab.config.PosX] = pieceObject;
        }
        // Red Elephant
        for (int i = 0; i < RElephantPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(RElephantPrefab.gameObject, RElephantPrefab.config.PosY[i], RElephantPrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RElephantPrefab.config.PosY[i], RElephantPrefab.config.PosX] = pieceObject;
        }
        // Red horse
        for (int i = 0; i < RHorsePrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(RHorsePrefab.gameObject, RHorsePrefab.config.PosY[i], RHorsePrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RHorsePrefab.config.PosY[i], RHorsePrefab.config.PosX] = pieceObject;
        }
        // Red Rook
        for (int i = 0; i < RRookPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(RRookPrefab.gameObject, RRookPrefab.config.PosY[i], RRookPrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RRookPrefab.config.PosY[i], RRookPrefab.config.PosX] = pieceObject;
        }
        // Red King
        for (int i = 0; i < RKingPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(RKingPrefab.gameObject, RKingPrefab.config.PosY[i], RKingPrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RKingPrefab.config.PosY[i], RKingPrefab.config.PosX] = pieceObject;
        }
        // Black Pawn
        for (int i = 0; i < BPawnPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BPawnPrefab.gameObject, BPawnPrefab.config.PosY[i], BPawnPrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BPawnPrefab.config.PosY[i], BPawnPrefab.config.PosX] = pieceObject;
        }
        // Black Cannon
        for (int i = 0; i < BCannonPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BCannonPrefab.gameObject, BCannonPrefab.config.PosY[i], BCannonPrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BCannonPrefab.config.PosY[i], BCannonPrefab.config.PosX] = pieceObject;
        }
        // Black Advisor
        for (int i = 0; i < BAdvisorPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BAdvisorPrefab.gameObject, BAdvisorPrefab.config.PosY[i], BAdvisorPrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BAdvisorPrefab.config.PosY[i], BAdvisorPrefab.config.PosX] = pieceObject;
        }
        // Black Elephant
        for (int i = 0; i < BElephantPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BElephantPrefab.gameObject, BElephantPrefab.config.PosY[i], BElephantPrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BElephantPrefab.config.PosY[i], BElephantPrefab.config.PosX] = pieceObject;
        }
        // Black Horse
        for (int i = 0; i < BHorsePrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BHorsePrefab.gameObject, BHorsePrefab.config.PosY[i], BHorsePrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BHorsePrefab.config.PosY[i], BHorsePrefab.config.PosX] = pieceObject;
        }
        // Black Rook
        for (int i = 0; i < BRookPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BRookPrefab.gameObject, BRookPrefab.config.PosY[i], BRookPrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BRookPrefab.config.PosY[i], BRookPrefab.config.PosX] = pieceObject;
        }
        //Black King
        for (int i = 0; i < BKingPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BKingPrefab.gameObject, BKingPrefab.config.PosY[i], BKingPrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BKingPrefab.config.PosY[i], BKingPrefab.config.PosX] = pieceObject;
        }
    }

    public void RestartGame()
    {
        if(currentSelectPiece != null)
        {
            DeselectPiece(currentSelectPiece);
            DeselectEvent.Invoke(true);
        }

        for (int i =0; i< 9; i++)
        {
            for(int j =0; j<11; j++)
            {
                Destroy(pieces[i, j]);
                pieces[i, j] = null;
            }
           
        }

        InitialSetup();
        UIManager.instance.ShowUI(false);
        isGameOver = false;
    }
}
