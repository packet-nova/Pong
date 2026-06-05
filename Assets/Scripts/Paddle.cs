using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Ball _ball;

    [SerializeField] private Player _playerController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _moveSpeed;

    public Player PlayerController => _playerController;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float input = 0f;

        if (_playerController == Player.One)
        {
            if (Keyboard.current.wKey.isPressed)
            {
                input = 1f;
            }

            if (Keyboard.current.sKey.isPressed)
            {
                input = -1f;
            }

        }

        if (_playerController == Player.Two)
        {
            if (_gameManager.IsVersusComputer)
            {
                input = GetAIInput();
            }

            else
            {
                if (Keyboard.current.upArrowKey.isPressed)
                {
                    input = 1f;
                }

                if (Keyboard.current.downArrowKey.isPressed)
                {
                    input = -1f;
                }
            }
        }

        _rigidBody.linearVelocity = new(0f, _moveSpeed * input);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out _))
        {
            _gameManager.PaddleHitByBall(this);
        }
    }

    private float GetAIInput()
    {
        if (_ball == null)
        {
            Debug.Log("NO BALL!");
            return 0f;
        }

        float yDelta = Mathf.Abs(_ball.transform.position.y - transform.position.y);

        if (yDelta >= 0.6f)
        {
            if (_ball.transform.position.y < transform.position.y)
            {
                return -1f;
            }
            else if (_ball.transform.position.y > transform.position.y)
            {
                return 1f;
            }
        }

        return 0;
    }

    public void GetBall(Ball ball) => _ball = ball;
}
