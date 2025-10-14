using UnityEngine;
using UnityEngine.SceneManagement;

namespace HentaiGame
{
    public class ChangeSceneService
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene(sceneName: SceneNameConstants.MainMenu);
        }

        public void GoToPerksScene()
        {
            SceneManager.LoadScene(sceneName: SceneNameConstants.PerksMenu);
        }

        public void GoToLevel(int level)
        {
            SceneManager.LoadScene(level + 1);
        }

        public void GoToNextLevel()
        {
            if (
                SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("Ты победил, молодец!");
                GameManager.Instance.ActivateFinalScreen();
            }
        }

        public void ResetLevel()
        {
            SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex);
        }
    }
}