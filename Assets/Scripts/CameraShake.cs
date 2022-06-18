using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _basicMultiChannelPerlin;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _basicMultiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void StartShake(float intensity)
    {
        _basicMultiChannelPerlin.m_AmplitudeGain = intensity;
        _basicMultiChannelPerlin.m_FrequencyGain = intensity;
    }

    public void EndShake()
    {
        _basicMultiChannelPerlin.m_AmplitudeGain = 0;
        _basicMultiChannelPerlin.m_FrequencyGain = 0;
    }
}
