using HentaiGame;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NextLevelPanel : MonoBehaviour
{
    [SerializeField] private Button _nextSceneButton;
    private ChangeSceneService _changeSceneService;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _nextSceneButton.onClick.AddListener(call: _changeSceneService.GoToNextLevel);
    }

    private void OnDisable()
    {
        _nextSceneButton.onClick.RemoveAllListeners();
    }

    [Inject]
    private void Construct(ChangeSceneService changeSceneService)
    {
        _changeSceneService = changeSceneService;
    }
}