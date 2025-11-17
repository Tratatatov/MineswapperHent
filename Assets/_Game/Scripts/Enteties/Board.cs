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

    public int TotalSafeTiles => _width * _height - _numMines;
    public int OpenedSafeTiles { get; private set; }

    public bool IsLevelComplete => OpenedSafeTiles >= TotalSafeTiles;

    public List<Tile> Tiles { get; }

    // Логика игры (мины, клики и т.д.) — без создания объектов
    public void ResetGameState()
    {
        OpenedSafeTiles = 0; // Сбрасываем счетчик при новой игре

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
            if (tile.IsMine && !tile.IsFlagged && tile.CanGetDamage)
                mineTiles.Add(item: tile);

        return mineTiles;
    }

    public void OnTileOpened(Tile tile)
    {
        if (!tile.IsMine && !tile.IsFlagged)
        {
            OpenedSafeTiles++;

            // Проверяем условие победы
            if (IsLevelComplete) GameEvents.OnTurnsOver?.Invoke();
        }
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