using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Character Player => _character;

    public Transform GameHolder { get => gameHolder; set => gameHolder = value; }
    public int Width { get => width; set => width = value; }
    public int Height { get => height; set => height = value; }

    [Header("��������� ����")]
    [SerializeField] private Transform tilePrefab;
    [SerializeField] private Transform gameHolder;

    [Header("��������� ������")]
    [SerializeField] private Character _character;

    private List<Tile> tiles = new();

    private int width;
    private int height;
    private int numMines;

    private readonly float tileSize = 0.5f;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateGameBoard(9, 9, 10); // Easy
                                   // CreateGameBoard(16, 16, 40); // Intermediate
                                   // CreateGameBoard(30, 16, 99); // Expert
        ResetGameState();

        _character.Activate(false);
    }

    public void CreateGameBoard(int width, int height, int numMines)
    {
        // Save the game parameters we're using.
        this.Width = width;
        this.Height = height;
        this.numMines = numMines;

        // Create the array of tiles.
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                // Position the tile in the correct place (centred).
                Transform tileTransform = Instantiate(tilePrefab);
                tileTransform.parent = GameHolder;
                float xIndex = col - ((width - 1) / 2.0f);
                float yIndex = row - ((height - 1) / 2.0f);
                tileTransform.localPosition = new Vector2(xIndex * tileSize, yIndex * tileSize);
                // Keep a reference to the tile for setting up the game.
                Tile tile = tileTransform.GetComponent<Tile>();
                tiles.Add(tile);
                tile.GameManager = this;
            }
        }
    }
    private void ResetGameState()
    {
        // Randomly shuffle the tile positions to get indices for mine positions.
        int[] minePositions = Enumerable.Range(0, tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f)).ToArray();

        // Set mines at the first numMines positions.
        for (int i = 0; i < numMines; i++)
        {
            int pos = minePositions[i];
            tiles[pos].IsMine = true;
        }

        // Update all the tiles to hold the correct number of mines.
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].MineCount = HowManyMines(i);
        }
    }

    // Given a location work out how many mines are surrounding it.
    private int HowManyMines(int location)
    {
        int count = 0;
        foreach (int pos in GetNeighbours(location))
        {
            if (tiles[pos].IsMine)
            {
                count++;
            }
        }
        return count;
    }

    // Given a position, return the positions of all neighbours.
    private List<int> GetNeighbours(int pos)
    {
        List<int> neighbours = new();
        int row = pos / Width;
        int col = pos % Width;
        // (0,0) is bottom left.
        if (row < (Height - 1))
        {
            neighbours.Add(pos + Width); // North
            if (col > 0)
            {
                neighbours.Add(pos + Width - 1); // North-West
            }
            if (col < (Width - 1))
            {
                neighbours.Add(pos + Width + 1); // North-East
            }
        }
        if (col > 0)
        {
            neighbours.Add(pos - 1); // West
        }
        if (col < (Width - 1))
        {
            neighbours.Add(pos + 1); // East
        }
        if (row > 0)
        {
            neighbours.Add(pos - Width); // South
            if (col > 0)
            {
                neighbours.Add(pos - Width - 1); // South-West
            }
            if (col < (Width - 1))
            {
                neighbours.Add(pos - Width + 1); // South-East
            }
        }
        return neighbours;
    }

    public void ClickNeighbours(Tile tile)
    {
        //int location = tiles.IndexOf(tile);
        //foreach (int pos in GetNeighbours(location))
        //{
        //    tiles[pos].ClickedTile();
        //}
    }

    public void ClickCross(Tile tile)
    {
        int location = tiles.IndexOf(tile);
        int row = location / Width;
        int col = location % Width;

        // ��������� � ��������� ������ �������, ������, ����� � ������ �����
        if (row < Height - 1) tiles[location + Width].Open(); // �������
        if (row > 0) tiles[location - Width].Open(); // ������
        if (col < Width - 1) tiles[location + 1].Open();    // ������
        if (col > 0) tiles[location - 1].Open();     // �����
    }

    public void GameOver()
    {
        // Disable clicks on all mines.
        foreach (Tile tile in tiles)
        {
            tile.ShowGameOverState();
        }
    }

    public void CheckGameOver()
    {
        // If there are numMines left active then we're done.
        int count = 0;
        foreach (Tile tile in tiles)
        {
            if (tile.Active)
            {
                count++;
            }
        }
        if (count == numMines)
        {
            // Flag and disable everything, we're done.
            Debug.Log("Winner!");
            foreach (Tile tile in tiles)
            {
                tile.Active = false;
                tile.SetFlaggedIfMine();
            }
        }
    }

    // Click on all surrounding tiles if mines are all flagged.

}
