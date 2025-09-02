using UnityEngine;

public class BoxTest : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    private Camera _camera;
    private bool _isDragging;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        var newPosition = _grid.WorldToCell(mousePosition);
        newPosition.z = 0;
        if (!_isDragging) return;
        transform.position = newPosition;
    }

    private void OnMouseDown()
    {
        _isDragging = true;
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }
}