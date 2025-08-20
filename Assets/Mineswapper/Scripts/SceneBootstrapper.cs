using UnityEngine;
namespace HentaiGame
{
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerMVC _playerMVC;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            // _playerMVC.Initialize(_gameManager.NumMines);
        }

    }
}
