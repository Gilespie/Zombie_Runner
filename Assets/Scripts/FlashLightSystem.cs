using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [Header("Limits of angle")]
    [SerializeField] private float _lightAngle = 70.0f;
    [SerializeField] private float _minimumAngle = 40.0f;
    [Header("Decrease amount per second")]
    [SerializeField] private float _intensityDecay = 0.1f;
    [SerializeField] private float _angleDecay = 0.5f;

    [SerializeField] private float _lightIntensity = 1.0f;
    private Light _flashLight;

    private void Start()
    {
        _flashLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    public void RestoreLightAngle(float amountRestore)
    {
        _flashLight.spotAngle = amountRestore;
    }

    public void AddLightIntensity(float amount)
    {
        _flashLight.intensity += amount;
    }

    private void DecreaseLightIntensity()
    {
        _flashLight.intensity -= _intensityDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if(_flashLight.spotAngle <= _minimumAngle)
        {
            return;
        }
        else
        {
            _flashLight.spotAngle -= _angleDecay * Time.deltaTime;
        }
    }
}