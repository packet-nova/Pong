using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody2d;
    [SerializeField] private float _maxInitialAngle;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxStartY;
    [SerializeField] private float _maxStartX;
    [SerializeField] private float _maxSpeed;

    public float MoveSpeed => _moveSpeed;
    public float MaxStartX => _maxStartX;
    public float MaxStartY => _maxStartY;

    private void Awake()
    {
        if (_rigidBody2d == null)
        {
            _rigidBody2d = GetComponent<Rigidbody2D>();
        }
    }

    private void Start()
    {
        InitialPush();
    }
    private void InitialPush()
    {
        Vector2 direction = Random.value < 0.5f ? Vector2.left : Vector2.right;

        float randomY = Random.Range(-_maxInitialAngle, _maxInitialAngle);

        if (Mathf.Abs(randomY) < 0.1f)
        {
            randomY = 0.1f * (Random.value < 0.5f ? 1 : -1);
        }

        direction.y = randomY;
        _rigidBody2d.linearVelocity = direction.normalized * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PaddleEffect>(out PaddleEffect effect))
        {
            Debug.Log("Ball collided with: " + collision.gameObject.name);
            effect.HitEffect();
        }

        AdjustSpeed(0.15f);

        Vector2 currentDirection = _rigidBody2d.linearVelocity.normalized;
        _rigidBody2d.linearVelocity = currentDirection * _moveSpeed;
    }
    private void AdjustSpeed(float amount)
    {
        float targetSpeed = _moveSpeed + amount;
        _moveSpeed = UnityEngine.Mathf.Clamp(targetSpeed, 0f, _maxSpeed);
    }
}