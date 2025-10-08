using UnityEngine;

namespace HentaiGame
{
    public class CharacterOnBoard : MonoBehaviour
    {
        private Vector2 _position;
        private SpriteRenderer _spriteRenderer;

        public void Initialize(SpriteRenderer characterSpriteRenderer, Sprite miniIconSprite)
        {
            _spriteRenderer = characterSpriteRenderer;
            _spriteRenderer.sprite = miniIconSprite;
            Activate(false);
        }

        public void MoveTo(Tile tile)
        {
            transform.position = tile.transform.position;
            _position = transform.position;
        }

        public void Activate(bool active)
        {
            if (active)
                _spriteRenderer.enabled = true;
            else
                _spriteRenderer.enabled = false;
        }
    }
}