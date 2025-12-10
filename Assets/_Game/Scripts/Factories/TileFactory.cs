using HentaiGame;
using UnityEngine;
using Zenject;

public class TileFactory
{
    private readonly CharacterOnBoard _characterOnBoard;
    private readonly CharacterStatsView _characterStatsView;
    private readonly PlayerDataLevel _playerDataLevel;
    private readonly Tile _tilePrefab;
    private readonly TileSpritesDataConfig _tileSpritesDataConfig;

    [Inject]
    public TileFactory(PlayerDataLevel playerDataLevel, CharacterOnBoard characterOnBoard,
        TileSpritesDataConfig tileSpritesDataConfig, CharacterStatsView characterStatsView, Tile tilePrefab)
    {
        _playerDataLevel = playerDataLevel;
        _characterOnBoard = characterOnBoard;
        _tileSpritesDataConfig = tileSpritesDataConfig;
        _characterStatsView = characterStatsView;
        _tilePrefab = tilePrefab;
    }

    public Tile Get()
    {
        Tile newTile = GameObject.Instantiate(original: _tilePrefab);
        newTile.Construct(characterOnBoard: _characterOnBoard, tileSpritesDataConfig: _tileSpritesDataConfig,
            characterStatsView: _characterStatsView, playerDataLevel: _playerDataLevel);
        return newTile;
    }
}