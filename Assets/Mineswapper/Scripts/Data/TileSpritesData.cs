using System.Collections.Generic;
using UnityEngine;

namespace HentaiGame
{
    [CreateAssetMenu(fileName = "Настройки тайлов", menuName = "Настройки/Спрайты тайлов")]
    public class TileSpritesData : ScriptableObject
    {
        [SerializeField] private List<Sprite> _unclickedTiles;
        [SerializeField] private List<Sprite> _clickedTiles;
        [SerializeField] private Sprite _flaggedTile;
        [SerializeField] private Sprite _mineTile;
        [SerializeField] private Sprite _mineWrongTile;
        [SerializeField] private Sprite _mineHitTile;
        [SerializeField] private List<Sprite> _backgroundTiles;

        public List<Sprite> UnclickedTiles => _unclickedTiles;
        public Sprite FlaggedTile => _flaggedTile;
        public List<Sprite> ClickedTiles => _clickedTiles;
        public Sprite MineTile => _mineTile;
        public Sprite MineWrongTile => _mineWrongTile;
        public Sprite MineHitTile => _mineHitTile;
        public List<Sprite> BackgroundTiles => _backgroundTiles;

        public Sprite GetRandomClickedTile()
        {
            var randomIndex = Random.Range(0, _clickedTiles.Count);
            return _clickedTiles[randomIndex];
        }

        public Sprite GetRandomUnclickedTile()
        {
            var randomIndex = Random.Range(0, _unclickedTiles.Count);
            return _unclickedTiles[randomIndex];
        }

        public Sprite GetRandomBackgroundTile()
        {
            var randomIndex = Random.Range(0, _backgroundTiles.Count);
            return _backgroundTiles[randomIndex];
        }
    }
}