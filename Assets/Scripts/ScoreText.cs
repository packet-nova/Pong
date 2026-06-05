using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public void Awake()
    {
        if (_text == null)
        {
            _text = GetComponent<TextMeshProUGUI>();
        }
    }
    public void SetScore(int score)
    {
        _text.text = score.ToString();
    }
}
