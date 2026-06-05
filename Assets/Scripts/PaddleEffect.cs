using UnityEngine;

public class PaddleEffect : MonoBehaviour
{
    private readonly Color _defaultColor = Color.white;
    private readonly float _effectDuration = .12f;

    [SerializeField] private Color _hitColor;

    private SpriteRenderer _spriteRenderer;
    private float _timer = 0f;
    private bool _isEffectActive = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
    void Update()
    {
        if (_isEffectActive)
        {
            _timer += Time.deltaTime;

            if (_timer >= _effectDuration)
            {
                _spriteRenderer.color = _defaultColor;
                _isEffectActive = false;
                _timer = 0f;
            }
        }

    }

    public void HitEffect()
    {
        _spriteRenderer.color = _hitColor;
        _timer = 0f;
        _isEffectActive = true;
    }
}
