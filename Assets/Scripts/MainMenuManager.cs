using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void StartOnePlayerGame()
    {
        GameManager.ChangeOpponent(GameMode.VsComputer);
        SceneManager.LoadScene(0);
    }
    public void StartTwoPlayerGame()
    {
        GameManager.ChangeOpponent(GameMode.VsHuman);
        SceneManager.LoadScene(0);
    }
}
