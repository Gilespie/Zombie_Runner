using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    [SerializeField] private int _ammoAmount = 5;
    [SerializeField] private AmmoType _ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            Ammo ammo = other.GetComponent<Ammo>(); 

            if(ammo != null)
            {
                ammo.IncreaseCurrentAmmo(_ammoType, _ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}