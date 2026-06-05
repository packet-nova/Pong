using UnityEngine;
using Assets.Scripts;
using System.Security.Cryptography;

public enum Player { None, One, Two }

public class GameManager : MonoBehaviour
{
    private int _scorePlayerOne = 0;
    private int _scorePlayerTwo = 0;
    private Ball _ball;

    [SerializeField] private ScoreText _scoreTextPlayerOne;
    [SerializeField] private ScoreText _scoreTextPlayerTwo;
    [SerializeField] private ScoreZone _scoreZonePlayerOne;
    [SerializeField] private ScoreZone _scoreZonePlayerTwo;

    [SerializeField] private Ball _basicBallPrefab;
    [SerializeField] private Ball _fastBallPrefab;
    [SerializeField] private Paddle _leftPaddle;
    [SerializeField] private Paddle _rightPaddle;

    [SerializeField] private AudioManager _audioManager;

    public void Start()
    {
        SpawnBasicBall();
        GivePaddlesTheBall();
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

    private void SpawnBasicBall()
    {
        float randomY = Random.Range(-_basicBallPrefab.MaxStartY, _basicBallPrefab.MaxStartY);
        Vector2 spawnPosition = new(0f, randomY);
        Ball newBall = Instantiate(_basicBallPrefab, spawnPosition, Quaternion.identity);
        _ball = newBall;
    }


    private void GivePaddlesTheBall()
    {
        _leftPaddle.GetBall(_ball);
        _rightPaddle.GetBall(_ball);
    }

    private void SpawnRandomBall()
    {
        Ball prefabToSpawn = Random.Range(0f, 0.5f) > 0.1f ? _basicBallPrefab : _fastBallPrefab;
        float randomY = Random.Range(-_basicBallPrefab.MaxStartY, _basicBallPrefab.MaxStartY);
        Vector2 spawnPosition = new(0f, randomY);
        Ball newBall = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}

