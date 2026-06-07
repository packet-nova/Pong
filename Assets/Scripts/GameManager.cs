using UnityEngine;
using Assets.Scripts;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum Player { None, One, Two }
public enum GameMode { VsComputer, VsHuman }

public class GameManager : MonoBehaviour
{
    private static bool _isVersusComputer;
    private int _scorePlayerOne = 0;
    private int _scorePlayerTwo = 0;
    private Ball _ball;
    private bool _isPaused;

    [SerializeField] private ScoreText _scoreTextPlayerOne;
    [SerializeField] private ScoreText _scoreTextPlayerTwo;
    [SerializeField] private ScoreZone _scoreZonePlayerOne;
    [SerializeField] private ScoreZone _scoreZonePlayerTwo;

    [SerializeField] private Ball _basicBallPrefab;
    [SerializeField] private Ball _fastBallPrefab;
    [SerializeField] private Paddle _leftPaddle;
    [SerializeField] private Paddle _rightPaddle;

    [SerializeField] private AudioManager _audioManager;

    public bool IsVersusComputer => _isVersusComputer;

    public void Start()
    {
        SpawnBasicBall();
        GivePaddlesTheBall();
        Debug.Log(IsVersusComputer);
    }

    public void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void BallEnteredScoreZone(ScoreData data)
    {
        switch (data.ScoreZone.ZoneOwner)
        {
            case Player.One:
                _scorePlayerTwo++;
                Debug.Log($"[GameManager] Player Two Scored! Total: {_scorePlayerTwo}");
                _scoreTextPlayerTwo.SetScore(_scorePlayerTwo);
                break;
            case Player.Two:
                _scorePlayerOne++;
                Debug.Log($"[GameManager] Player One Scored! Total: {_scorePlayerOne}");
                _scoreTextPlayerOne.SetScore(_scorePlayerOne);
                break;
        }

        _audioManager.PlayScoreSound();
        Destroy(data.Ball.gameObject);
        SpawnBasicBall();
        GivePaddlesTheBall();
    }

    public void PaddleHitByBall(Paddle paddle) => _audioManager.PlayPaddleHitSound(paddle);

    public void RestartGame() => SceneManager.LoadScene(0);
    public void LoadMainMenu() => SceneManager.LoadScene(1);

    private void SpawnBasicBall()
    {
        float randomY = Random.Range(-_basicBallPrefab.MaxStartY, _basicBallPrefab.MaxStartY);
        Vector2 spawnPosition = new(0f, randomY);
        Ball newBall = Instantiate(_basicBallPrefab, spawnPosition, Quaternion.identity);
        _ball = newBall;
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        _audioManager.ToggleMuteAll();
        Time.timeScale = _isPaused ? 0f : 1f;
    }

    private void GivePaddlesTheBall()
    {
        _leftPaddle.GetBall(_ball);
        _rightPaddle.GetBall(_ball);
    }
    public static void ChangeOpponent(GameMode mode) => _isVersusComputer = (mode == GameMode.VsComputer);

    private void SpawnRandomBall()
    {
        Ball prefabToSpawn = Random.Range(0f, 0.5f) > 0.1f ? _basicBallPrefab : _fastBallPrefab;
        float randomY = Random.Range(-_basicBallPrefab.MaxStartY, _basicBallPrefab.MaxStartY);
        Vector2 spawnPosition = new(0f, randomY);
        Ball newBall = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}