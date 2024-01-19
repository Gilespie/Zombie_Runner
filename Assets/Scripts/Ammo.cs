using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _ammoCountMax = 10;
    private int _currentAmmo;

    private void Start()
    {
        _currentAmmo = _ammoCountMax;
    }

    public int GetCurrentAmmo()
    {
        return _currentAmmo;
    }

    public void IncreaseCurrentAmmo(int amount)
    {
        _currentAmmo += Mathf.Abs(amount);
    }

    public void DecreaseCurrentAmmo()
    {
        _currentAmmo--;
    }
}