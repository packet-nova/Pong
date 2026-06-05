using UnityEngine;
using UnityEngine.InputSystem;

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
            if (Keyboard.current.upArrowKey.isPressed)
            {
                input = 1f;
            }

            if (Keyboard.current.downArrowKey.isPressed)
            {
                input = -1f;
            }

            //if (_ball.transform.position.y != transform.position.y)
            //{
            //    transform.position = new(transform.position.x, _ball.transform.position.y);
            //}
        }

        if (_playerController == Player.Two)
        {
            if (_ball == null)
            {
                Debug.Log("NO BALL!");
                return;
            }

            float yDelta = Mathf.Abs(_ball.transform.position.y - transform.position.y);

            if (_ball.transform.position.y > transform.position.y)
            {
                if (yDelta >= 0.6f)
                {
                    input = 1f;
                }
            }
            else if (_ball.transform.position.y < transform.position.y)
            {
                if (yDelta >= 0.6f)
                {
                    input = -1f;
                }
            }

            else
            {
                input = 0f;
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

    public void GetBall(Ball ball) => _ball = ball;
}
