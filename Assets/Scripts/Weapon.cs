using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private Ammo _ammoSlot;
    [SerializeField] private AmmoType _ammoType;

    [Header("ShootSFX")]
    [SerializeField] private ParticleSystem _muzzleFlashPS;
    [SerializeField] private AudioClip _audioClip;

    [Header("Decals")]
    [SerializeField] private GameObject _hitImpactPS;
    [SerializeField] private float _delayToDelete = 15f;

    [Header("Settings")]
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _damage = 15f;
    [SerializeField] private float _delayBetweenShots = 0.5f;

    private bool _canShoot = true;

    private void OnEnable()
    {
        _canShoot = true;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;

        if (_ammoSlot.GetCurrentAmmo(_ammoType) > 0)
        {
            _ammoSlot.DecreaseCurrentAmmo(_ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
        }

        yield return new WaitForSeconds(_delayBetweenShots);

        _canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlashPS.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.collider.GetComponent<EnemyHealth>();

            if (target != null)
            {
                target.TakeDamage(_damage);
            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if(!hit.collider.GetComponent<EnemyHealth>())
        {
            GameObject impactFX = Instantiate(_hitImpactPS, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactFX, _delayToDelete);
        }
    }
}