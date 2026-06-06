using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [Header("Audio Channels")]
    [SerializeField] private AudioSource _bgm;
    [SerializeField] private AudioSource _sfx;

    [Header("Game Sounds")]
    [SerializeField] private AudioClip _scoreSound;
    [SerializeField] private AudioClip _leftPaddleHit;
    [SerializeField] private AudioClip _rightPaddleHit;
    [SerializeField] private AudioClip _backgroundMusic;

    [Header("UI Sounds")]
    [SerializeField] private AudioClip _uiButtonClick;


    void Start()
    {
        _bgm.clip = _backgroundMusic;
        _bgm.Play();
    }
    public void PlayButtonClick() => _sfx.PlayOneShot(_uiButtonClick);
    public void PlayScoreSound() => _sfx.PlayOneShot(_scoreSound);
    public void PlayPaddleHitSound(Paddle paddle)
    {
        AudioClip selectedClip = paddle.PlayerController switch
        {
            Player.One => _leftPaddleHit,
            Player.Two => _rightPaddleHit,
            _ => _leftPaddleHit
        };

        _sfx.PlayOneShot(selectedClip, 3f);
    }

    public void ToggleMuteAll()
    {
        _audioMixer.GetFloat("MasterVolume", out float current);
        _audioMixer.SetFloat("MasterVolume", (current > -80f ? -80f : 0f));
    }
}



