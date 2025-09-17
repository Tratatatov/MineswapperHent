using System.Collections.Generic;
using UnityEngine;

namespace HentaiGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backGroundSpriteRenderer;

        private Sprite _backgroundTile;
        private Board _board;
        private CharacterOnBoard _characterOnBoard;
        private List<Sprite> _clickedTiles;
        private Sprite _doorSprite;
        private Sprite _flaggedTile;
        private Sprite _mineHitTile;
        private Sprite _mineTile;
        private Sprite _mineWrongTile;
        private SpriteRenderer _spriteRenderer;
        private Sprite _unclickedTile;

        private List<Sprite> _unclickedTiles;

        public bool IsOpened { get; }

        public bool IsFlagged { get; private set; }

        public bool CanBeClicked { get; private set; }

        public bool IsMine { get; private set; }

        public int MineCount { get; private set; }

        private void OnMouseOver()
        {
            if (GlobalState.GameState == GameState.GameOver || !CanBeClicked) return;

            if (Input.GetMouseButton(0))
                OnClick();
            else if (Input.GetMouseButtonDown(1))
                SetFlag();
        }

        public void Initialize(CharacterOnBoard characterOnBoard, TileSpritesData tileSpritesData, Board board)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _characterOnBoard = characterOnBoard;
            _board = board;
            IsMine = false;
            IsFlagged = false;
            CanBeClicked = true;
            _unclickedTile = tileSpritesData.GetRandomUnclickedTile();
            _spriteRenderer.sprite = _unclickedTile;
            _mineHitTile = tileSpritesData.MineHitTile;
            _mineTile = tileSpritesData.MineTile;
            _mineWrongTile = tileSpritesData.MineWrongTile;
            _flaggedTile = tileSpritesData.FlaggedTile;
            _unclickedTiles = tileSpritesData.UnclickedTiles;
            _clickedTiles = tileSpritesData.ClickedTiles;
            _backGroundSpriteRenderer.sprite = tileSpritesData.GetRandomBackgroundTile();
        }

        public void SetMine(bool value)
        {
            IsMine = value;
        }

        public void SetActive(bool value)
        {
            CanBeClicked = value;
        }

        public void Open()
        {
            if (!CanBeClicked || IsFlagged)
                return;

            CanBeClicked = false;

            if (IsMine)
            {
                _spriteRenderer.sprite = _mineTile;
            }
            else
            {
                _spriteRenderer.sprite = _clickedTiles[index: MineCount];
                _backGroundSpriteRenderer.enabled = true;
            }
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
                    _spriteRenderer.sprite = _mineTile;
                else if (IsFlagged & !IsMine)
                    _spriteRenderer.sprite = _mineWrongTile;
            }
        }

        public void SetFlaggedIfMine()
        {
            if (IsMine)
            {
                IsFlagged = true;
                _spriteRenderer.sprite = _flaggedTile;
            }
        }

        private void SetFlag()
        {
            IsFlagged = !IsFlagged;
            if (IsFlagged)
            {
                _spriteRenderer.sprite = _flaggedTile;
                ServiceLocator.Get<PlayerMVC>().DecreaseFlags(1);
            }
            else
            {
                _spriteRenderer.sprite = _unclickedTile;
                ServiceLocator.Get<PlayerMVC>().AddFlags(1);
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
                OpenTile();
            //if (!CanBeClicked && MineCount > 0) _board.ExpandIfFlagged(this);
        }

        private bool CantBeClicked()
        {
            return !CanBeClicked || IsFlagged;
        }

        private void OpenTile()
        {
            Open();
            ServiceLocator.Get<PlayerMVC>().DecreaseTurns();

            //_board.CheckGameOver();
        }

        private void Booom()
        {
            _spriteRenderer.sprite = _mineHitTile;
            CanBeClicked = false;
            ServiceLocator.Get<PlayerMVC>().DecreaseHp(1);
        }

        private void MoveCharacter()
        {
            _characterOnBoard.Activate(true);
            _characterOnBoard.MoveTo(this);
        }
    }
}