using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    [Header("Tile Sprites")]
    [SerializeField] private Sprite _unclickedTile;
    [SerializeField] private Sprite _flaggedTile;
    [SerializeField] private List<Sprite> _clickedTiles;
    [SerializeField] private Sprite _mineTile;
    [SerializeField] private Sprite _mineWrongTile;
    [SerializeField] private Sprite _mineHitTile;
    [SerializeField] private Sprite _doorSprite;
    [Header("GM set via code")]
    public GameManager GameManager;

    private SpriteRenderer _spriteRenderer;
    public bool Flagged = false;
    public bool Active = true;
    public bool IsMine = false;
    public int MineCount = 0;


    void Awake()
    {
        // This should always exist due to the RequireComponent helper.
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        // If it hasn't already been pressed.

        if (Input.GetMouseButtonDown(0))
        {
            // If left click reveal the tile contents.
            ClickedTile();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // If right click toggle flag on/off.
            Flagged = !Flagged;
            if (Flagged)
            {
                _spriteRenderer.sprite = _flaggedTile;
            }
            else
            {
                _spriteRenderer.sprite = _unclickedTile;
            }
        }
    }

    public void Open()
    {
        if (Active & !Flagged)
        {
            Active = false;

            if (IsMine)
            {
                //Show mine sprite
                _spriteRenderer.sprite = _mineTile;
            }

            else
            {
                _spriteRenderer.sprite = _clickedTiles[MineCount];
            }
        }
    }
    public void ClickedTile()
    {
        GameManager.Instance.Player.Activate(true);
        GameManager.Instance.Player.MoveTo(this);


        // Ensure it can no longer be pressed again.
        Active = false;
        if (IsMine)
        {
            // Game over :(
            _spriteRenderer.sprite = _mineHitTile;
            GameManager.GameOver();
        }
        else
        {
            // It was a safe click, set the correct sprite.
            _spriteRenderer.sprite = _clickedTiles[MineCount];
            // ¬сегда открываем 4 соседние клетки при клике
            GameManager.ClickCross(this);
            // Check for game over.
            GameManager.CheckGameOver();
        }

    }




    // If this tile should be shown at game over, do so.
    public void ShowGameOverState()
    {
        if (Active)
        {
            Active = false;
            if (IsMine & !Flagged)
            {
                // If mine and not flagged show mine.
                _spriteRenderer.sprite = _mineTile;
            }
            else if (Flagged & !IsMine)
            {
                // If flagged incorrectly show crossthrough mine
                _spriteRenderer.sprite = _mineWrongTile;
            }
        }
    }

    // Helper function to flag remaning mines on game completion.
    public void SetFlaggedIfMine()
    {
        if (IsMine)
        {
            Flagged = true;
            _spriteRenderer.sprite = _flaggedTile;
        }
    }

}