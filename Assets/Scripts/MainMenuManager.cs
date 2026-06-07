using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void StartOnePlayerGame()
    {
        GameManager.ChangeOpponent(GameMode.VsComputer);
        SceneManager.LoadScene("Pong");
    }
    public void StartTwoPlayerGame()
    {
        GameManager.ChangeOpponent(GameMode.VsHuman);
        SceneManager.LoadScene("Pong");
    }
}
