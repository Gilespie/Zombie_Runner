using UnityEngine;
using UnityEngine.InputSystem;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverCanvas;
    private PlayerInput _playerInput;
    private WeaponSwitcher _weaponSwitcher;

    private void Start()
    {
        _weaponSwitcher = GetComponentInChildren<WeaponSwitcher>();
        _playerInput = GetComponent<PlayerInput>();
        _gameOverCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandlerDeath()
    {
        _weaponSwitcher.enabled = false;
        _playerInput.enabled = false;
        _gameOverCanvas.enabled = true;
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}