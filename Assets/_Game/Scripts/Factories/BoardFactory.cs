using System.Collections.Generic;
using HentaiGame;
using UnityEngine;
using Zenject;

public class BoardFactory
{
    private const float TileSize = 0.5f;
    private readonly TileFactory _tileFactory;
    private readonly TileHolder _tileHolder;

    [Inject]
    public BoardFactory(TileFactory tileFactory, TileHolder tileHolder)
    {
        _tileFactory = tileFactory;
        _tileHolder = tileHolder;
    }

    public Board Get(int width, int height, int numMines)
    {
        // Создаём список тайлов через TileFactory (здесь, в фабрике)
        List<Tile> tiles = new();
        for (int row = 0; row < height; row++)
        for (int col = 0; col < width; col++)
        {
            Tile newTile = _tileFactory.Get(); // Создание тайла через фабрику
            newTile.transform.SetParent(p: _tileHolder.transform); // Установка родителя
            float xIndex = col - (width - 1) / 2.0f;
            float yIndex = row - (height - 1) / 2.0f;
            newTile.transform.localPosition = new Vector2(xIndex * TileSize, yIndex * TileSize);
            tiles.Add(item: newTile); // Добавление в список
        }

        // Создаём Board, передавая готовый список тайлов
        Board newBoard = new(width: width, height: height, numMines: numMines, tiles: tiles);

        // Настройка: инициализация тайлов и начальное состояние
        foreach (Tile tile in tiles)
            tile.Initialize(board: newBoard);
        newBoard.ResetGameState();

        return newBoard;
    }
}