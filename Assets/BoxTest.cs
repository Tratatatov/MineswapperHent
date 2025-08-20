using UnityEngine;

public class BoxTest : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    private bool _isDragging;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int newPosition = _grid.WorldToCell((Vector3)mousePosition);
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
