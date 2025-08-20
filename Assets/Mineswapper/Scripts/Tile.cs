using System.Collections.Generic;
using UnityEngine;
namespace HentaiGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [Header("Tile Sprites")]
        [SerializeField] private List<Sprite> _unclickedTiles;
        [SerializeField] private Sprite _unclickedTile;
        [SerializeField] private Sprite _flaggedTile;
        [SerializeField] private List<Sprite> _clickedTiles;
        [SerializeField] private Sprite _mineTile;
        [SerializeField] private Sprite _mineWrongTile;
        [SerializeField] private Sprite _mineHitTile;
        [SerializeField] private Sprite _backgroundTile;
        [SerializeField] private SpriteRenderer _backgroundTileRenderer;

        [Header("GM set via code")]
        public GameManager gameManager;

        private SpriteRenderer _spriteRenderer;
        public bool flagged = false;
        public bool active = true;
        public bool isMine = false;
        public int mineCount = 0;


        void Awake()
        {
            // This should always exist due to the RequireComponent helper.
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _backgroundTileRenderer.gameObject.SetActive(false);
            SetRandomUnclickedTile();
        }

        private void SetRandomUnclickedTile()
        {
            int randomIndex = Random.Range(0, _unclickedTiles.Count);
            _spriteRenderer.sprite = _unclickedTiles[randomIndex];
        }

        private void OnMouseOver()
        {
            // If it hasn't already been pressed.
            if (active)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // If left click reveal the tile contents.
                    ClickedTile();
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    // If right click toggle flag on/off.
                    flagged = !flagged;
                    if (flagged)
                    {
                        _spriteRenderer.sprite = _flaggedTile;
                    }
                    else
                    {
                        _spriteRenderer.sprite = _unclickedTile;
                    }
                    _backgroundTileRenderer.gameObject.SetActive(true);
                }
            }
            else
            {
                // If you're pressing both mouse buttons.
                if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
                {
                    // Check for valid expansion.
                    gameManager.ExpandIfFlagged(this);
                }
            }
        }

        public void ClickedTile()
        {
            // Don't allow left clicks on flags.
            if (active & !flagged)
            {
                // Ensure it can no longer be pressed again.
                active = false;
                if (isMine)
                {
                    // Game over :(
                    _spriteRenderer.sprite = _mineHitTile;
                    gameManager.PlayerMvc.TakeDamage(1);
                    //gameManager.GameOver();
                }
                else
                {
                    // It was a safe click, set the correct sprite.
                    _spriteRenderer.sprite = _clickedTiles[mineCount];
                    if (mineCount == 0)
                    {
                        // Register that the click should expand out to the neighbours.
                        gameManager.ClickNeighbours(this);
                    }
                    // Whenever we successfully make a change check for game over.
                    gameManager.CheckGameOver();
                }
                _backgroundTileRenderer.gameObject.SetActive(true);
            }


        }

        // If this tile should be shown at game over, do so.
        public void ShowGameOverState()
        {
            if (active)
            {
                active = false;
                if (isMine & !flagged)
                {
                    // If mine and not flagged show mine.
                    _spriteRenderer.sprite = _mineTile;
                }
                else if (flagged & !isMine)
                {
                    // If flagged incorrectly show crossthrough mine
                    _spriteRenderer.sprite = _mineWrongTile;
                }
                _backgroundTileRenderer.gameObject.SetActive(true);
            }
        }

        // Helper function to flag remaning mines on game completion.
        public void SetFlaggedIfMine()
        {
            if (isMine)
            {
                flagged = true;
                _spriteRenderer.sprite = _flaggedTile;
            }
        }

    }
}
