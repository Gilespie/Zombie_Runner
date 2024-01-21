using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] _ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType AmmoType;
        public int AmmoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).AmmoAmount;
    }

    public void DecreaseCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).AmmoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int amount)
    {
        GetAmmoSlot(ammoType).AmmoAmount += amount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in _ammoSlots)
        {
            if(slot.AmmoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}