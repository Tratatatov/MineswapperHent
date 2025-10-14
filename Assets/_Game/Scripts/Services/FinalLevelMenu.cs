using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HentaiGame
{
    public class FinalLevelMenu : MonoBehaviour
    {
        [SerializeField] private Button _restartGameButton;
        

        private void OnEnable()
        {
            _restartGameButton.onClick.AddListener(() =>
                SceneManager.LoadScene(sceneName: SceneNameConstants.Bootstrapper));
        }

        private void OnDisable()
        {
            _restartGameButton.onClick.RemoveAllListeners();
        }
    }
}