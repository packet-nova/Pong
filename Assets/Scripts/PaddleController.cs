using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float _leftMoveSpeed;
    [SerializeField] private float _rightMoveSpeed;
    [SerializeField] private GameObject _leftPaddle;
    [SerializeField] private GameObject _rightPaddle;
    [SerializeField] private GameObject _northWall;
    [SerializeField] private GameObject _southWall;

    private Rigidbody2D _leftRb;
    private Rigidbody2D _rightRb;
    private BoxCollider2D _leftBoxCollider;
    private BoxCollider2D _rightBoxCollider;

    void Start()
    {
        _leftRb = _leftPaddle.GetComponent<Rigidbody2D>();
        _rightRb = _rightPaddle.GetComponent<Rigidbody2D>();
        _leftBoxCollider = _rightPaddle.GetComponent<BoxCollider2D>();
        _rightBoxCollider = _rightPaddle.GetComponent<BoxCollider2D>();
    }    
}
