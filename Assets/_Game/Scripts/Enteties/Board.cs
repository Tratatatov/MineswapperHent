using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HentaiGame
{
    public class Board
    {
        private readonly Transform _gameHolder;
        private readonly int _height;
        private readonly int _numMines;
        private readonly Tile _tilePrefab;
        private readonly List<Tile> _tiles = new();
        private readonly float _tileSize = 0.5f;
        private readonly int _width;
        private readonly CharacterOnBoard _characterOnBoard;
        private readonly TileSpritesData _tileSpritesData;

        public Board(BoardConfig boardConfig, Tile tilePrefab, Transform gameHolder, CharacterOnBoard characterOnBoard,
            TileSpritesData tileSpritesData)
        {
            _tileSpritesData = tileSpritesData;
            _characterOnBoard = characterOnBoard;
            _width = boardConfig.Width;
            _height = boardConfig.Height;
            _numMines = boardConfig.NumMines;
            _tilePrefab = tilePrefab;
            _gameHolder = gameHolder;
        }

        public void CreateGameBoard(int width, int height, int numMines)
        {
            // Create the array of tiles.
            for (int row = 0; row < height; row++)
            for (int col = 0; col < width; col++)
            {
                // Position the tile in the correct place (centred).
                Tile newTile = GameObject.Instantiate(original: _tilePrefab);
                newTile.Initialize(characterOnBoard: _characterOnBoard, tileSpritesData: _tileSpritesData, this);
                newTile.transform.parent = _gameHolder;
                float xIndex = col - (width - 1) / 2.0f;
                float yIndex = row - (height - 1) / 2.0f;
                newTile.transform.localPosition = new Vector2(xIndex * _tileSize, yIndex * _tileSize);
                // Keep a reference to the tile for setting up the game.
                _tiles.Add(item: newTile);
                //tile.gameManager = this;
            }
        }

        public void ResetGameState()
        {
            // Randomly shuffle the tile positions to get indices for mine positions.
            int[] minePositions = Enumerable.Range(0, count: _tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f))
                .ToArray();

            // Set mines at the first numMines positions.
            for (int i = 0; i < _numMines; i++)
            {
                int pos = minePositions[i];
                _tiles[index: pos].SetMine(true);
            }

            // Update all the tiles to hold the correct number of mines.
            for (int i = 0; i < _tiles.Count; i++) _tiles[index: i].SetMineCount(HowManyMines(location: i));
        }

        // Given a location work out how many mines are surrounding it.
        private int HowManyMines(int location)
        {
            int count = 0;
            foreach (int pos in GetNeighbours(pos: location))
                if (_tiles[index: pos].IsMine)
                    count++;

            return count;
        }

        // Given a position, return the positions of all neighbours.
        private List<int> GetNeighbours(int pos)
        {
            List<int> neighbours = new();
            int row = pos / _width;
            int col = pos % _width;
            // (0,0) is bottom left.
            if (row < _height - 1)
            {
                neighbours.Add(pos + _width); // North
                if (col > 0) neighbours.Add(pos + _width - 1); // North-West
                if (col < _width - 1) neighbours.Add(pos + _width + 1); // North-East
            }

            if (col > 0) neighbours.Add(pos - 1); // West
            if (col < _width - 1) neighbours.Add(pos + 1); // East
            if (row > 0)
            {
                neighbours.Add(pos - _width); // South
                if (col > 0) neighbours.Add(pos - _width - 1); // South-West
                if (col < _width - 1) neighbours.Add(pos - _width + 1); // South-East
            }

            return neighbours;
        }

        // public void ClickNeighbours(Tile tile)
        // {
        //     var location = _tiles.IndexOf(tile);
        //     foreach (var pos in GetNeighbours(location)) _tiles[pos].OnClick();
        // }
        //
        // public void GameOver()
        // {
        //     // Disable clicks on all mines.
        //     foreach (var tile in _tiles) tile.ShowGameOverState();
        // }

        // public void CheckGameOver()
        // {
        //     // If there are numMines left active then we're done.
        //     // int count = 0;
        //     // foreach (Tile tile in _tiles)
        //     //     if (tile.CanBeClicked)
        //     //         count++;
        //     //
        //     // if (count == _numMines)
        //     // {
        //     //     Debug.Log("Winner!");
        //     //     foreach (Tile tile in _tiles)
        //     //     {
        //     //         tile.SetActive(false);
        //     //         tile.SetFlaggedIfMine();
        //     //     }
        //     // }
        // }

        // Click on all surrounding tiles if mines are all flagged.
        // public void ExpandIfFlagged(Tile tile)
        // {
        //     int location = _tiles.IndexOf(item: tile);
        //     // Get the number of flags.
        //     int flag_count = 0;
        //     foreach (int pos in GetNeighbours(pos: location))
        //         if (_tiles[index: pos].IsFlagged)
        //             flag_count++;
        //
        //     // If we have the right number click surrounding tiles.
        //     if (flag_count == tile.MineCount)
        //         // Clicking a flag does nothing so this is safe.
        //         ClickNeighbours(tile: tile);
        // }

        public void ClickNeighbours(Tile tile)
        {
            int location = _tiles.IndexOf(item: tile);
            foreach (int pos in GetNeighbours(pos: location))
                _tiles[index: pos].OpenRecursive();
        }

        // public void GameOver()
        // {
        //     Debug.Log("Game Over");
        // }
    }
}