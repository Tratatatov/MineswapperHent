using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace HentaiGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerMVC _playerMvc;

        public Transform tilePrefab;
        public Transform gameHolder;

        public List<Tile> Tiles = new();

        public int Width;
        public int Height;
        public int NumMines;

        public readonly float tileSize = 0.5f;

        public PlayerMVC PlayerMvc => _playerMvc;


        // Start is called before the first frame update
        void Start()
        {
            CreateGameBoard(Width, Height, NumMines); 
            ResetGameState();
        }

        public void CreateGameBoard(int width, int height, int numMines)
        {
            // Save the game parameters we're using.
            this.Width = width;
            this.Height = height;
            this.NumMines = numMines;

            // Create the array of tiles.
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    // Position the tile in the correct place (centred).
                    Transform tileTransform = Instantiate(tilePrefab);
                    tileTransform.parent = gameHolder;
                    float xIndex = col - ((width - 1) / 2.0f);
                    float yIndex = row - ((height - 1) / 2.0f);
                    tileTransform.localPosition = new Vector2(xIndex * tileSize, yIndex * tileSize);
                    // Keep a reference to the tile for setting up the game.
                    Tile tile = tileTransform.GetComponent<Tile>();
                    Tiles.Add(tile);
                    tile.gameManager = this;
                }
            }
        }
        private void ResetGameState()
        {
            // Randomly shuffle the tile positions to get indices for mine positions.
            int[] minePositions = Enumerable.Range(0, Tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f)).ToArray();

            // Set mines at the first numMines positions.
            for (int i = 0; i < NumMines; i++)
            {
                int pos = minePositions[i];
                Tiles[pos].isMine = true;
            }

            // Update all the tiles to hold the correct number of mines.
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].mineCount = HowManyMines(i);
            }
        }

        // Given a location work out how many mines are surrounding it.
        private int HowManyMines(int location)
        {
            int count = 0;
            foreach (int pos in GetNeighbours(location))
            {
                if (Tiles[pos].isMine)
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
            int location = Tiles.IndexOf(tile);
            foreach (int pos in GetNeighbours(location))
            {
                Tiles[pos].ClickedTile();
            }
        }

        public void GameOver()
        {
            // Disable clicks on all mines.
            foreach (Tile tile in Tiles)
            {
                tile.ShowGameOverState();
            }
        }

        public void CheckGameOver()
        {
            // If there are numMines left active then we're done.
            int count = 0;
            foreach (Tile tile in Tiles)
            {
                if (tile.active)
                {
                    count++;
                }
            }
            if (count == NumMines)
            {
                // Flag and disable everything, we're done.
                Debug.Log("Winner!");
                foreach (Tile tile in Tiles)
                {
                    tile.active = false;
                    tile.SetFlaggedIfMine();
                }
            }
        }

        // Click on all surrounding tiles if mines are all flagged.
        public void ExpandIfFlagged(Tile tile)
        {
            int location = Tiles.IndexOf(tile);
            // Get the number of flags.
            int flag_count = 0;
            foreach (int pos in GetNeighbours(location))
            {
                if (Tiles[pos].flagged)
                {
                    flag_count++;
                }
            }
            // If we have the right number click surrounding tiles.
            if (flag_count == tile.mineCount)
            {
                // Clicking a flag does nothing so this is safe.
                ClickNeighbours(tile);
            }
        }
    }

}