using UnityEngine;

public class CharacterIconPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _characterIcon;

    public void Enable(bool value) => _characterIcon.SetActive(value);

    public void SetIconOn(Vector2 position)
    {
        _characterIcon.transform.position = position;
    }
}
