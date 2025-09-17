using UnityEngine.SceneManagement;

namespace HentaiGame
{
    public static class ChangeSceneService
    {
        public static void GoToMainMenu()
        {
            SceneManager.LoadScene(sceneBuildIndex: SceneConsts.MainMenu);
        }

        public static void GoToPerksScene()
        {
            SceneManager.LoadScene(sceneBuildIndex: SceneConsts.Perks);
        }

        public static void GoToLevel(int level)
        {
            SceneManager.LoadScene(level + 1);
        }

        public static void GoToNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public static void ResetLevel()
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