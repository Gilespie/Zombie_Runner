using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int _currentWeaponIndex = 0;

    private void Start()
    {
        SetWeaponActive();
    }

    private void Update()
    {
        int previosWeapon = _currentWeaponIndex;

        ProcessKeyInput();
        ProcessScrollheel();

        if(previosWeapon != _currentWeaponIndex)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(_currentWeaponIndex >= transform.childCount - 1)
            {
                _currentWeaponIndex = 0;
            }
            else
            {
                _currentWeaponIndex++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(_currentWeaponIndex <= 0)
            {
                _currentWeaponIndex = transform.childCount - 1;
            }
            else
            {
                _currentWeaponIndex--;
            }
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentWeaponIndex = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentWeaponIndex = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentWeaponIndex = 2;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == _currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }
}