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

    private Player red;
    private Player black;
    public Player currentPlayer;
    public Player otherPlayer;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pieces = new GameObject[9, 10];

        red = new Player("red", true);
        black = new Player("black", false);

        currentPlayer = red;
        otherPlayer = black;

        InitialSetup();
    }

    private void InitialSetup()
    {
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
        locations.RemoveAll(gp => gp.x < 0 || gp.x >= 9 || gp.y < 0 || gp.y > 9);

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
        //if (pieceToCapture.GetComponent<Piece>().type == PieceType.King)
        //{
        //    Debug.Log(currentPlayer.name + " wins!");
        //    Destroy(board.GetComponent<TileSelector>());
        //    Destroy(board.GetComponent<MoveSelector>());
        //}
        currentPlayer.capturedPieces.Add(pieceToCapture);
        pieces[gridPoint.x, gridPoint.y] = null;
        Destroy(pieceToCapture);
    }

    public void SelectPiece(GameObject piece)
    {
        board.SelectPiece(piece);
    }

    public void DeselectPiece(GameObject piece)
    {
        board.DeselectPiece(piece);
    }

    public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }

    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
        Debug.Log(gridPoint);
        if (gridPoint.x > 8 || gridPoint.y > 9 || gridPoint.x < 0 || gridPoint.y < 1)
        {
            return null;
        }

        return pieces[gridPoint.x, gridPoint.y];
    }

    public Vector2Int GridForPiece(GameObject piece)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 1; j < 10; j++)
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

    void GenerateChessBoard()
    {
        //// Red Pawn
        //for (int i = 0; i < RPawnPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(RPawnPrefab.config.PosY[i], RPawnPrefab.config.PosX));

        //    Instantiate(RPawnPrefab, position, Quaternion.identity);

        //}
        // Red Cannon
        for (int i = 0; i < RCannonPrefab.config.PosY.Length; i++)
        {
            //  var position = Geometry.PointFromGrid(new Vector2Int(RCannonPrefab.config.PosY[i], RCannonPrefab.config.PosX));
            // Instantiate(RCannonPrefab, position, Quaternion.identity);
            GameObject pieceObject = board.AddPiece(RCannonPrefab.gameObject, RCannonPrefab.config.PosY[i], RCannonPrefab.config.PosX);
            red.pieces.Add(pieceObject);
            pieces[RCannonPrefab.config.PosY[i], RCannonPrefab.config.PosX] = pieceObject;
        }
        // Red Advisor
        //for (int i = 0; i < RAdvisorPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(RAdvisorPrefab.config.PosY[i], RAdvisorPrefab.config.PosX));
        //    Instantiate(RAdvisorPrefab, position, Quaternion.identity);
        //}
        //// Red Elephant
        //for (int i = 0; i < RElephantPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(RElephantPrefab.config.PosY[i], RElephantPrefab.config.PosX));
        //    Instantiate(RElephantPrefab, position, Quaternion.identity);
        //}
        //// Red horse
        //for (int i = 0; i < RHorsePrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(RHorsePrefab.config.PosY[i], RHorsePrefab.config.PosX));
        //    Instantiate(RHorsePrefab, position, Quaternion.identity);
        //}
        //// Red Rook
        //for (int i = 0; i < RRookPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(RRookPrefab.config.PosY[i], RRookPrefab.config.PosX));
        //    Instantiate(RRookPrefab, position, Quaternion.identity);
        //}
        //// Red King
        //for (int i = 0; i < RKingPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(RKingPrefab.config.PosY[i], RKingPrefab.config.PosX));
        //    Instantiate(RKingPrefab, position, Quaternion.identity);
        //}
        //// Black Pawn
        //for (int i = 0; i < BPawnPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(BPawnPrefab.config.PosY[i], BPawnPrefab.config.PosX));
        //    Instantiate(BPawnPrefab, position, Quaternion.identity);
        //}
        // Black Cannon
        for (int i = 0; i < BCannonPrefab.config.PosY.Length; i++)
        {
            GameObject pieceObject = board.AddPiece(BCannonPrefab.gameObject, BCannonPrefab.config.PosY[i], BCannonPrefab.config.PosX);
            black.pieces.Add(pieceObject);
            pieces[BCannonPrefab.config.PosY[i], BCannonPrefab.config.PosX] = pieceObject;
        }
        //// Black Advisor
        //for (int i = 0; i < BAdvisorPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(BAdvisorPrefab.config.PosY[i], BAdvisorPrefab.config.PosX));
        //    Instantiate(BAdvisorPrefab, position, Quaternion.identity);
        //}
        //// Black Elephant
        //for (int i = 0; i < BElephantPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(BElephantPrefab.config.PosY[i], BElephantPrefab.config.PosX));
        //    Instantiate(BElephantPrefab, position, Quaternion.identity);
        //}
        //// Black Horse
        //for (int i = 0; i < BHorsePrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(BHorsePrefab.config.PosY[i], BHorsePrefab.config.PosX));
        //    Instantiate(BHorsePrefab, position, Quaternion.identity);
        //}
        //// Black Rook
        //for (int i = 0; i < BRookPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(BRookPrefab.config.PosY[i], BRookPrefab.config.PosX));
        //    Instantiate(BRookPrefab, position, Quaternion.identity);
        //}
        ////Black King
        //for (int i = 0; i < BKingPrefab.config.PosY.Length; i++)
        //{
        //    var position = Geometry.PointFromGrid(new Vector2Int(BKingPrefab.config.PosY[i], BKingPrefab.config.PosX));
        //    Instantiate(BKingPrefab, position, Quaternion.identity);
        //}
    }
}
