using HentaiGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debugger : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    private void Update()
    {
        _gameState = GlobalState.GameState;
        Debug.Log(PlayerProgeress.CurrentLevel.ToString());
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName: SceneManager.GetActiveScene().name);
    }
}