using UnityEngine;

public class FramerateLimiter : MonoBehaviour
{
    [SerializeField] private int _framerate;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = _framerate;
    }
}