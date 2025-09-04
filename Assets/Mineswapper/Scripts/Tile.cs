using System.Collections.Generic;
using UnityEngine;

namespace HentaiGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backGroundSpriteRenderer;
        public bool IsFlagged => _isFlagged;

        public bool CanBeClicked => _canBeClicked;

        public bool IsMine => _isMine;

        public int MineCount => _mineCount;

        // public Board Board => _board;

        private Sprite _backgroundTile;
        private CharacterOnBoard _characterOnBoard;
        private List<Sprite> _clickedTiles;
        private List<Sprite> _unclickedTiles;
        private Sprite _doorSprite;
        private Sprite _flaggedTile;
        private Sprite _mineHitTile;
        private Sprite _mineTile;
        private Sprite _mineWrongTile;
        private SpriteRenderer _spriteRenderer;
        private Sprite _unclickedTile;
        private bool _isFlagged;
        private bool _canBeClicked;
        private bool _isMine;
        private int _mineCount;
        private Board _board;


        public void Initialize(CharacterOnBoard characterOnBoard, TileSpritesData tileSpritesData, Board board)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _characterOnBoard = characterOnBoard;
            _board = board;
            _isMine = false;
            _isFlagged = false;
            _canBeClicked = true;
            _unclickedTile = tileSpritesData.GetRandomUnclickedTile();
            _mineHitTile = tileSpritesData.MineHitTile;
            _mineTile = tileSpritesData.MineTile;
            _mineWrongTile = tileSpritesData.MineWrongTile;
            //_backgrou3ndTile = tileSpritesData.BackgroundTiles;
            _flaggedTile = tileSpritesData.FlaggedTile;
            _unclickedTiles = tileSpritesData.UnclickedTiles;
            _clickedTiles = tileSpritesData.ClickedTiles;
            _backGroundSpriteRenderer.sprite = tileSpritesData.GetRandomBackgroundTile();
        }

        public void SetMine(bool value)
        {
            _isMine = value;
        }

        public void SetActive(bool value)
        {
            _canBeClicked = value;
        }

        public void Open()
        {
            if (!CanBeClicked || IsFlagged)
                return;

            _canBeClicked = false;

            if (_isMine)
                _spriteRenderer.sprite = _mineTile;
            else
            {
                _spriteRenderer.sprite = _clickedTiles[MineCount];
                _backGroundSpriteRenderer.enabled = true;
            }
        }

        // public void OnClick()
        // {
        //     _characterOnBoard.Activate(true);
        //     _characterOnBoard.MoveTo(this);
        //
        //
        //     // Ensure it can no longer be pressed again.
        //     _canBeClicked = false;
        //
        //     if (_isMine)
        //     {
        //         // Game over :(
        //         _spriteRenderer.sprite = _mineHitTile;
        //         GameEvents.OnGameOver?.Invoke();
        //     }
        //     else
        //     {
        //         // It was a safe click, set the correct sprite.
        //         _spriteRenderer.sprite = _clickedTiles[_mineCount];
        //         _backGroundSpriteRenderer.enabled = true;
        //         Debug.Log("Clicked tile");
        //         //GameManager.ClickCross(this);
        //         //GameManager.CheckGameOver();
        //     }
        // }

        public void SetMineCount(int value)
        {
            _mineCount = value;
        }


        // If this tile should be shown at game over, do so.
        public void ShowGameOverState()
        {
            if (_canBeClicked)
            {
                _canBeClicked = false;
                if (_isMine & !_isFlagged)
                    // If mine and not flagged show mine.
                    _spriteRenderer.sprite = _mineTile;
                else if (_isFlagged & !_isMine)
                    // If flagged incorrectly show crossthrough mine
                    _spriteRenderer.sprite = _mineWrongTile;
            }
        }

        // Helper function to flag remaning mines on game completion.
        public void SetFlaggedIfMine()
        {
            if (_isMine)
            {
                _isFlagged = true;
                _spriteRenderer.sprite = _flaggedTile;
            }
        }

        private void OnMouseOver()
        {
            // If it hasn't already been pressed.

            if (Input.GetMouseButtonDown(0))
                // If left click reveal the tile contents.
                OnClick();
            else if (Input.GetMouseButtonDown(1))
                // If right click toggle flag on/off.
                SetFlag();
        }

        private void SetFlag()
        {
            _isFlagged = !_isFlagged;
            if (_isFlagged)
                _spriteRenderer.sprite = _flaggedTile;
            else
                _spriteRenderer.sprite = _unclickedTile;
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
            if (!CanBeClicked || IsFlagged)
                return;

            _characterOnBoard.Activate(true);
            _characterOnBoard.MoveTo(this);

            if (_isMine)
            {
                _spriteRenderer.sprite = _mineHitTile;
                _canBeClicked = false;
                GameEvents.OnGameOver?.Invoke();
                _board.GameOver();
            }
            else
            {
                OpenRecursive();
                _board.CheckGameOver();

                // Если тайл уже открыт и имеет число > 0, можно расширить открытие соседей, если флаги стоят правильно
                if (!CanBeClicked && MineCount > 0) _board.ExpandIfFlagged(this);
            }
        }
    }
}