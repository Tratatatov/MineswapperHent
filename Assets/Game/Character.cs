using UnityEngine;

public class Character : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 _position;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
