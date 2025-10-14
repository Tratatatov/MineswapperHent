using System.Collections.Generic;
using System.Linq;
using HentaiGame;
using UnityEngine;

public class Board
{
    private readonly int _height;
    private readonly int _numMines;
    private readonly int _width;
    private CharacterOnBoard _characterOnBoard;

    // Конструктор: принимает только готовый список тайлов (чистая логика)
    public Board(int width, int height, int numMines, List<Tile> tiles)
    {
        _width = width;
        _height = height;
        _numMines = numMines;
        Tiles = tiles;
    }

    public List<Tile> Tiles { get; }

    // Логика игры (мины, клики и т.д.) — без создания объектов
    public void ResetGameState()
    {
        // Randomly shuffle the tile positions to get indices for mine positions.
        int[] minePositions = Enumerable.Range(0, count: Tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f)).ToArray();

        // Set mines at the first numMines positions.
        for (int i = 0; i < _numMines; i++)
        {
            int pos = minePositions[i];
            Tiles[index: pos].SetMine(true);
        }

        // Update all the tiles to hold the correct number of mines.
        for (int i = 0; i < Tiles.Count; i++)
            Tiles[index: i].SetMineCount(HowManyMines(location: i));
    }

    public List<Tile> GetOpenedMineTiles()
    {
        List<Tile> mineTiles = new();
        foreach (Tile tile in Tiles)
            if (tile.IsMine && tile.IsFlagged)
                mineTiles.Add(item: tile);

        return mineTiles;
    }

    public List<Tile> GetClosedMineTiles()
    {
        List<Tile> mineTiles = new();
        foreach (Tile tile in Tiles)
            if (tile.IsMine && !tile.IsFlagged)
                mineTiles.Add(item: tile);

        return mineTiles;
    }


    private int HowManyMines(int location)
    {
        int count = 0;
        foreach (int pos in GetNeighbours(pos: location))
            if (Tiles[index: pos].IsMine)
                count++;
        return count;
    }

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

    public void ClickNeighbours(Tile tile)
    {
        int location = Tiles.IndexOf(item: tile);
        foreach (int pos in GetNeighbours(pos: location))
            Tiles[index: pos].OpenRecursive();
    }
}


// using System.Collections.Generic;
// using System.Linq;
// using HentaiGame;
// using UnityEngine;
//
// // public class BoardFactory
// // {
//     // private BoardConfig _boardConfig;
//     // private TileFactory _tileFactory;
//     // private TileHolder _tileHolder;
//     //
//     // public Board Get(int width, int height, int numMines)
//     // {
//     //     Board newBoard = new();
//     //     for (int row = 0; row < height; row++)
//     //     for (int col = 0; col < width; col++)
//     //     {
//     //         // Position the tile in the correct place (centred).
//     //         Tile newTile = _tileFactory.Get();
//     //         newTile.Initialize(board: newBoard);
//     //         newTile.transform.parent = _gameHolder;
//     //         float xIndex = col - (width - 1) / 2.0f;
//     //         float yIndex = row - (height - 1) / 2.0f;
//     //         newTile.transform.localPosition = new Vector2(xIndex * _tileSize, yIndex * _tileSize);
//     //         _tiles.Add(item: newTile);
//     //     }
//     // }
//     public class BoardFactory
//     {
//         [Inject] private BoardConfig _boardConfig;  // Инъекция конфига (если используется)
//         [Inject] private TileFactory _tileFactory;  // Инъекция фабрики тайлов (теперь "содержится" здесь)
//         [Inject] private TileHolder _tileHolder;    // Инъекция держателя тайлов (Transform для родителя)
//
//         private const float _tileSize = 0.5f;  // Константа размера тайла
//
//         // Метод фабрики: создаёт и настраивает Board
//         public Board Get(int width, int height, int numMines)
//         {
//             // Создаём список тайлов через TileFactory (здесь, в фабрике)
//             List<Tile> tiles = new();
//             for (int row = 0; row < height; row++)
//             for (int col = 0; col < width; col++)
//             {
//                 Tile newTile = _tileFactory.Get();  // Создание тайла через фабрику
//                 newTile.transform.SetParent(_tileHolder);  // Установка родителя
//                 float xIndex = col - (width - 1) / 2.0f;
//                 float yIndex = row - (height - 1) / 2.0f;
//                 newTile.transform.localPosition = new Vector2(xIndex * _tileSize, yIndex * _tileSize);
//                 tiles.Add(newTile);  // Добавление в список
//             }
//
//             // Создаём Board, передавая готовый список тайлов
//             Board newBoard = new Board(width, height, numMines, tiles);
//         
//             // Настройка: инициализация тайлов и начальное состояние
//             foreach (Tile tile in tiles)
//                 tile.Initialize(board: newBoard);
//             newBoard.ResetGameState();
//         
//             return newBoard;
//         }
//     }
//
//
//
// //     public class Board
// //     {
// //         private readonly int _height;
// //         private readonly int _numMines;
// //         private readonly List<Tile> _tiles = new();
// //         private readonly int _width;
// //         private CharacterOnBoard _characterOnBoard;
// //
// //         public void ResetGameState()
// //         {
// //             // Randomly shuffle the tile positions to get indices for mine positions.
// //             int[] minePositions = Enumerable.Range(0, count: _tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f))
// //                 .ToArray();
// //
// //             // Set mines at the first numMines positions.
// //             for (int i = 0; i < _numMines; i++)
// //             {
// //                 int pos = minePositions[i];
// //                 _tiles[index: pos].SetMine(true);
// //             }
// //
// //             // Update all the tiles to hold the correct number of mines.
// //             for (int i = 0; i < _tiles.Count; i++) _tiles[index: i].SetMineCount(HowManyMines(location: i));
// //         }
// //
// //         // Given a location work out how many mines are surrounding it.
// //         private int HowManyMines(int location)
// //         {
// //             int count = 0;
// //             foreach (int pos in GetNeighbours(pos: location))
// //                 if (_tiles[index: pos].IsMine)
// //                     count++;
// //
// //             return count;
// //         }
// //
// //         // Given a position, return the positions of all neighbours.
// //         private List<int> GetNeighbours(int pos)
// //         {
// //             List<int> neighbours = new();
// //             int row = pos / _width;
// //             int col = pos % _width;
// //             // (0,0) is bottom left.
// //             if (row < _height - 1)
// //             {
// //                 neighbours.Add(pos + _width); // North
// //                 if (col > 0) neighbours.Add(pos + _width - 1); // North-West
// //                 if (col < _width - 1) neighbours.Add(pos + _width + 1); // North-East
// //             }
// //
// //             if (col > 0) neighbours.Add(pos - 1); // West
// //             if (col < _width - 1) neighbours.Add(pos + 1); // East
// //             if (row > 0)
// //             {
// //                 neighbours.Add(pos - _width); // South
// //                 if (col > 0) neighbours.Add(pos - _width - 1); // South-West
// //                 if (col < _width - 1) neighbours.Add(pos - _width + 1); // South-East
// //             }
// //
// //             return neighbours;
// //         }
// //
// //         public void ClickNeighbours(Tile tile)
// //         {
// //             int location = _tiles.IndexOf(item: tile);
// //             foreach (int pos in GetNeighbours(pos: location))
// //                 _tiles[index: pos].OpenRecursive();
// //         }
// //     }
// // }
// //
// //         public class Board
// //         {
// //             private readonly int _height;
// //             private readonly int _numMines;
// //             private readonly List<Tile> _tiles = new();
// //             private readonly float _tileSize = 0.5f;
// //             private readonly int _width;
// //             private BoardConfig _boardConfig;
// //             private CharacterOnBoard _characterOnBoard;
// //
// //             [Inject]
// //             public Board(CharacterOnBoard characterOnBoard)
// //             {
// //                 _characterOnBoard = characterOnBoard;
// //                 _height = boardConfig.Height;
// //                 _numMines = NumMines;
// //             }
// //         }
// //     }
// // }
//
// // using System.Collections.Generic;
// // using System.Linq;
// // using UnityEngine;
// // using Zenject;
// //
// // namespace HentaiGame
// // {
// //     public class Board
// //     {
// //         private readonly List<Tile> _tiles = new();
// //         private readonly float _tileSize = 0.5f;
// //         private CharacterOnBoard _characterOnBoard;
// //         private Transform _gameHolder;
// //         private int _height;
// //         private int _numMines;
// //         private TileFactory _tileFactory;
// //         private TileSpritesDataConfig _tileSpritesDataConfig;
// //         private int _width;
// //
// //         [Inject]
// //         public Board(TileFactory tileFactory)
// //         {
// //             _tileFactory = tileFactory;
// //         }
// //
// //         [Inject]
// //         public void Construct(BoardConfig boardConfig, Tile tilePrefab, TileHolder gameHolder,
// //             CharacterOnBoard characterOnBoard,
// //             TileSpritesDataConfig tileSpritesDataConfig)
// //         {
// //             _tileSpritesDataConfig = tileSpritesDataConfig;
// //             _characterOnBoard = characterOnBoard;
// //             _width = boardConfig.Width;
// //             _height = boardConfig.Height;
// //             _numMines = boardConfig.NumMines;
// //             _tilePrefab = tilePrefab;
// //             _gameHolder = gameHolder.transform;
// //         }
// //
// //         public void CreateGameBoard(int width, int height, int numMines)
// //         {
// //             // Create the array of tiles.
// //             for (int row = 0; row < height; row++)
// //             for (int col = 0; col < width; col++)
// //             {
// //                 // Position the tile in the correct place (centred).
// //                 Tile newTile = GameObject.Instantiate(original: _tilePrefab);
// //                 newTile.Initialize(this);
// //                 newTile.transform.parent = _gameHolder;
// //                 float xIndex = col - (width - 1) / 2.0f;
// //                 float yIndex = row - (height - 1) / 2.0f;
// //                 newTile.transform.localPosition = new Vector2(xIndex * _tileSize, yIndex * _tileSize);
// //                 // Keep a reference to the tile for setting up the game.
// //                 _tiles.Add(item: newTile);
// //                 //tile.gameManager = this;
// //             }
// //         }
// //
// //         public void ResetGameState()
// //         {
// //             // Randomly shuffle the tile positions to get indices for mine positions.
// //             int[] minePositions = Enumerable.Range(0, count: _tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f))
// //                 .ToArray();
// //
// //             // Set mines at the first numMines positions.
// //             for (int i = 0; i < _numMines; i++)
// //             {
// //                 int pos = minePositions[i];
// //                 _tiles[index: pos].SetMine(true);
// //             }
// //
// //             // Update all the tiles to hold the correct number of mines.
// //             for (int i = 0; i < _tiles.Count; i++) _tiles[index: i].SetMineCount(HowManyMines(location: i));
// //         }
// //
// //         // Given a location work out how many mines are surrounding it.
// //         private int HowManyMines(int location)
// //         {
// //             int count = 0;
// //             foreach (int pos in GetNeighbours(pos: location))
// //                 if (_tiles[index: pos].IsMine)
// //                     count++;
// //
// //             return count;
// //         }
// //
// //         // Given a position, return the positions of all neighbours.
// //         private List<int> GetNeighbours(int pos)
// //         {
// //             List<int> neighbours = new();
// //             int row = pos / _width;
// //             int col = pos % _width;
// //             // (0,0) is bottom left.
// //             if (row < _height - 1)
// //             {
// //                 neighbours.Add(pos + _width); // North
// //                 if (col > 0) neighbours.Add(pos + _width - 1); // North-West
// //                 if (col < _width - 1) neighbours.Add(pos + _width + 1); // North-East
// //             }
// //
// //             if (col > 0) neighbours.Add(pos - 1); // West
// //             if (col < _width - 1) neighbours.Add(pos + 1); // East
// //             if (row > 0)
// //             {
// //                 neighbours.Add(pos - _width); // South
// //                 if (col > 0) neighbours.Add(pos - _width - 1); // South-West
// //                 if (col < _width - 1) neighbours.Add(pos - _width + 1); // South-East
// //             }
// //
// //             return neighbours;
// //         }
// //
// //         public void ClickNeighbours(Tile tile)
// //         {
// //             int location = _tiles.IndexOf(item: tile);
// //             foreach (int pos in GetNeighbours(pos: location))
// //                 _tiles[index: pos].OpenRecursive();
// //         }
// //     }
// // }