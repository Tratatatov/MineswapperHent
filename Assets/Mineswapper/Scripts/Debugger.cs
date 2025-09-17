using HentaiGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debugger : MonoBehaviour
{
    [SerializeField] GameState _gameState;
 
     void Update()
    {
        _gameState = GlobalState.GameState;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}