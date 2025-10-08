using UnityEngine;
using UnityEngine.SceneManagement;

namespace HentaiGame
{
    public class ChangeSceneService
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene(sceneBuildIndex: SceneConsts.MainMenu);
        }

        public void GoToPerksScene()
        {
            SceneManager.LoadScene(sceneBuildIndex: SceneConsts.Perks);
        }

        public void GoToLevel(int level)
        {
            SceneManager.LoadScene(level + 1);
        }

        public void GoToNextLevel()
        {
            if (
                SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 3)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                Debug.Log("Ты победил, молодец!");
        }

        public void ResetLevel()
        {
            SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex);
        }
    }
}

public class SceneConsts
{
    public const int MainMenu = 0;
    public const int Perks = 1;
}