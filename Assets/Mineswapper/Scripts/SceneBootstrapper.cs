using UnityEngine;
namespace HentaiGame
{
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerMVC _playerMVC;
        [SerializeField] private GameManager _gameManager;
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _playerMVC.Initialize(_gameManager.NumMines);
        }

    }
}
