using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float _angleRestore = 90f;
    [SerializeField] private float _intensityAmount = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(_angleRestore);
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(_intensityAmount);
            Destroy(gameObject);
        }
    }
}