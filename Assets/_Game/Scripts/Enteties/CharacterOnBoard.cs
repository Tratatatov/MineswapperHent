using UnityEngine;

namespace HentaiGame
{
    public class CharacterOnBoard : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private HealEffect _healEffect;
        private Vector2 _position;

        private void Start()
        {
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

        public void PlayHealEffect()
        {
            // _healEffect.Play();
        }
    }
}