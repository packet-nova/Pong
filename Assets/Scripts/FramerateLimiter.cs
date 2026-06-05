using UnityEngine;

public class FramerateLimiter : MonoBehaviour
{
    [SerializeField] private int _framerate = 60;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = _framerate;
    }
}