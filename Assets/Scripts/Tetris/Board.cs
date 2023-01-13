using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Tilemap Tilemap { get; private set; }
    public Piece ActivePiece { get; private set; }

    private const int OneLineBurningScoreCount = 100;
    private const int TwoLineBurningScoreCount = 300;
    private const int ThreeLineBurningScoreCount = 700;
    private const int TetrisScoreCount = 1500;

    [Header("Components")]
    public TetrominoData[] tetrominoes;
    public TMP_Text activeScoreText;
    public TMP_Text requiredScoreCountText;
    [Header("Parametrs")]
    public Vector2Int boardSize = new (10, 20);
    public Vector3Int spawnPosition = new (-1, 8, 0);
    public int requiredScoreCount = 2000;
    public int activeScoreCount = 0;
    public float moveDelay = 0.1f;

    public bool isStart;
    
    public RectInt Bounds {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    private void Awake()
    {
        Tilemap = GetComponentInChildren<Tilemap>();
        ActivePiece = GetComponentInChildren<Piece>();

        for (int i = 0; i < tetrominoes.Length; i++) {
            tetrominoes[i].Initialize();
        }

        requiredScoreCountText.text = "Нужно набрать: " + requiredScoreCount;
    }

    public void SpawnPiece()
    {
        isStart = true;
        
        int random = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[random];

        ActivePiece.Initialize(this, spawnPosition, data);

        if (IsValidPosition(ActivePiece, spawnPosition)) {
            Set(ActivePiece);
        } else {
            GameOver();
        }
    }

    public void GameOver()
    {
        Tilemap.ClearAllTiles();
        activeScoreCount = 0;
        UpdateTextScoreCount();
        // Do anything else you want on game over here..
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            Vector3Int tilePosition = piece.Cells[i] + piece.Position;
            Tilemap.SetTile(tilePosition, piece.Data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            Vector3Int tilePosition = piece.Cells[i] + piece.Position;
            Tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = Bounds;

        // The position is only valid if every cell is valid
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            Vector3Int tilePosition = piece.Cells[i] + position;

            // An out of bounds tile is invalid
            if (!bounds.Contains((Vector2Int)tilePosition)) {
                return false;
            }

            // A tile already occupies the position, thus invalid
            if (Tilemap.HasTile(tilePosition)) {
                return false;
            }
        }

        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = Bounds;
        int row = bounds.yMin;
        int burnedLinesCount = 0;
            
        // Clear from bottom to top
        while (row < bounds.yMax)
        {
            // Only advance to the next row if the current is not cleared
            // because the tiles above will fall down when a row is cleared
            if (IsLineFull(row)) {
                LineClear(row);
                burnedLinesCount++;
            } else {
                row++;
            }
        }
        AddScore(burnedLinesCount);
    }

    public bool IsLineFull(int row)
    {
        RectInt bounds = Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            // The line is not full if a tile is missing
            if (!Tilemap.HasTile(position)) {
                return false;
            }
        }

        return true;
    }

    public void AddScore(int burnedLineCount)
    {
        switch (burnedLineCount)
        {
            case 1:
                activeScoreCount += OneLineBurningScoreCount;
                UpdateTextScoreCount();
                break;
            case 2:
                activeScoreCount += TwoLineBurningScoreCount;
                UpdateTextScoreCount();
                break;
            case 3:
                activeScoreCount += ThreeLineBurningScoreCount;
                UpdateTextScoreCount();
                break;
            case 4:
                activeScoreCount += TetrisScoreCount;
                UpdateTextScoreCount();
                break;
        }
    }

    private void UpdateTextScoreCount()
    {
        activeScoreText.text = "Набрано очков: " + activeScoreCount;
    }

    public void LineClear(int row)
    {
        RectInt bounds = Bounds;

        // Clear all tiles in the row
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            Tilemap.SetTile(position, null);
        }

        // Shift every row above down one
        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = Tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                Tilemap.SetTile(position, above);
            }

            row++;
        }
    }

}
