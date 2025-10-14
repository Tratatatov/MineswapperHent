using System.Collections.Generic;
using UnityEngine;

namespace HentaiGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backGroundSpriteRenderer;
        [SerializeField] private SpriteRenderer _flagSpriteRenderer;
        [SerializeField] private TileSpritesDataConfig _tileSpritesDataConfig;
        [SerializeField] private SpriteRenderer _foregroundSpriteRenderer;
        private Sprite _backgroundTile;
        private Board _board;
        private CharacterOnBoard _characterOnBoard;
        private CharacterStatsView _characterStatsView;
        private List<Sprite> _clickedTiles;
        private Sprite _flaggedTile;
        private Sprite _mineHitTile;
        private Sprite _mineTile;
        private Sprite _mineWrongTile;
        private PlayerDataLevel _playerDataLevel;
        private Sprite _unclickedTile;

        private List<Sprite> _unclickedTiles;

        public bool IsOpened { get; }

        public bool IsFlagged { get; private set; }

        public bool CanBeClicked { get; private set; }

        public bool IsMine { get; private set; }

        public int MineCount { get; private set; }

        private void OnMouseOver()
        {
            if (GameManager.Instance.GameOverService.IsGameOver || !CanBeClicked) return;

            if (Input.GetMouseButton(0))
            {
                Debug.Log("Клик");
                OnClick();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Флаг");
                SetFlag();
            }
        }

        public void Construct(CharacterOnBoard characterOnBoard, TileSpritesDataConfig tileSpritesDataConfig,
            CharacterStatsView characterStatsView, PlayerDataLevel playerDataLevel)
        {
            _playerDataLevel = playerDataLevel;
            _characterOnBoard = characterOnBoard;
            _tileSpritesDataConfig = tileSpritesDataConfig;
            _characterStatsView = characterStatsView;
        }

        public void Initialize(Board board)
        {
            _board = board;
            IsMine = false;
            IsFlagged = false;
            CanBeClicked = true;
            _unclickedTile = _tileSpritesDataConfig.GetRandomUnclickedTile();
            _foregroundSpriteRenderer.sprite = _unclickedTile;
            _mineHitTile = _tileSpritesDataConfig.MineHitTile;
            _mineTile = _tileSpritesDataConfig.MineTile;
            _mineWrongTile = _tileSpritesDataConfig.MineWrongTile;
            _flaggedTile = _tileSpritesDataConfig.FlaggedTile;
            _unclickedTiles = _tileSpritesDataConfig.UnclickedTiles;
            _clickedTiles = _tileSpritesDataConfig.ClickedTiles;
            _backGroundSpriteRenderer.sprite = _tileSpritesDataConfig.GetRandomBackgroundTile();
            _flagSpriteRenderer.gameObject.SetActive(false);
        }

        public void SetMine(bool value)
        {
            IsMine = value;
        }

        public void Open()
        {
            if (CantBeClicked())
                return;

            CanBeClicked = false;

            _foregroundSpriteRenderer.sprite = _clickedTiles[index: MineCount];
            // _foregroundSpriteRenderer.enabled = false;
            _backGroundSpriteRenderer.enabled = true;
            _characterStatsView.DecreaseTurns();
        }

        public void ShowMineHit()
        {
            _foregroundSpriteRenderer.sprite = _mineHitTile;
            _backGroundSpriteRenderer.enabled = true;
        }

        public void ShowMineSafe()
        {
            _foregroundSpriteRenderer.sprite = _mineTile;
            _backGroundSpriteRenderer.enabled = true;
        }

        public void ShowEmpty()
        {
            _foregroundSpriteRenderer.sprite = _clickedTiles[index: MineCount];
            _backGroundSpriteRenderer.enabled = true;
        }


        public void SetMineCount(int value)
        {
            MineCount = value;
        }

        public void ShowGameOverState()
        {
            if (CanBeClicked)
            {
                CanBeClicked = false;
                if (IsMine & !IsFlagged)
                    _foregroundSpriteRenderer.sprite = _mineTile;
                else if (IsFlagged & !IsMine)
                    _foregroundSpriteRenderer.sprite = _mineWrongTile;
            }
        }

        public void SetFlaggedIfMine()
        {
            if (IsMine)
            {
                IsFlagged = true;
                _foregroundSpriteRenderer.sprite = _flaggedTile;
            }
        }

        private void SetFlag()
        {
            if (!IsFlagged)
            {
                if (_playerDataLevel.Flags <= 0)
                    return;
                _characterStatsView.DecreaseFlags();
                // _flagSpriteRenderer.sprite = _flaggedTile;
                _flagSpriteRenderer.gameObject.SetActive(true);
                IsFlagged = true;
            }
            else
            {
                _flagSpriteRenderer.gameObject.SetActive(false);
                // _flagSpriteRenderer.sprite = _unclickedTile;
                _characterStatsView.IncreaseFlags();
                IsFlagged = false;
            }
        }


        public void OpenRecursive()
        {
            if (!CanBeClicked || IsFlagged)
                return;

            Open();

            // Если нет мин вокруг, открыть соседние тайлы рекурсивно
            if (MineCount == 0 && !IsMine) _board.ClickNeighbours(this);
        }

        public void OnClick()
        {
            if (CantBeClicked())
                return;

            MoveCharacter();

            if (IsMine)
                Booom();

            else
                //OpenRecursive();
                Open();
            //if (!CanBeClicked && MineCount > 0) _board.ExpandIfFlagged(this);
        }

        private bool CantBeClicked()
        {
            return !CanBeClicked || IsFlagged;
        }

        private void Booom()
        {
            _foregroundSpriteRenderer.sprite = _mineHitTile;
            CanBeClicked = false;
            _characterStatsView.DecreaseTurns();
            _characterStatsView.DecreaseHp();
        }

        private void MoveCharacter()
        {
            _characterOnBoard.Activate(true);
            _characterOnBoard.MoveTo(this);
        }
    }
}