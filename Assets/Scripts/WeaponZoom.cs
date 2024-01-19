using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    private FirstPersonController _firstPersonController;

    [Header("FOV Settings")]
    [SerializeField] private float _aimFOV = 35f;
    [SerializeField] private float _mainFOV = 70f;
    [SerializeField] private float _zoomSpeed = 5f;
    private bool _isZoomed = false;
    private float _deadZone = 0.1f;

    [Header("Sensetivity")]
    [SerializeField] private float _aimFOVSensitivity = 0.5f;
    [SerializeField] private float _mainFOVSensitivity = 2f;


    private void Start()
    {
        _firstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isZoomed = !_isZoomed;
        }

        if (_isZoomed)
        {
            DecreaseFov();
        }
        else
        {
            IncreaseFov();
        }
    }

    private void DecreaseFov()
    {
        _camera.m_Lens.FieldOfView = Mathf.Lerp(_camera.m_Lens.FieldOfView, _aimFOV, Time.deltaTime * _zoomSpeed);

        if (_camera.m_Lens.FieldOfView - _aimFOV <= _deadZone)
        {
            _camera.m_Lens.FieldOfView = _aimFOV;
            Debug.Log($"Done!{_camera.m_Lens.FieldOfView}");
        }
        _firstPersonController.RotationSpeed = _aimFOVSensitivity;
    }

    private void IncreaseFov()
    {
        _camera.m_Lens.FieldOfView = Mathf.Lerp(_camera.m_Lens.FieldOfView, _mainFOV, Time.deltaTime * _zoomSpeed);

        if (_mainFOV - _camera.m_Lens.FieldOfView <= _deadZone)
        {
            _camera.m_Lens.FieldOfView = _mainFOV;
            Debug.Log($"Done!{_camera.m_Lens.FieldOfView}");
        }

        _firstPersonController.RotationSpeed = _mainFOVSensitivity;
    }
}