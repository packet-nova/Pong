using Assets.Scripts;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Player _zoneOwner;
    public Player ZoneOwner => _zoneOwner;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball ball))
        {
            ScoreData data = new(this, ball);
            _gameManager.BallEnteredScoreZone(data);
        }
    }
}