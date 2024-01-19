using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _fpCamera;
    [SerializeField] private Ammo _ammo;

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

    private void Update()
    {
        Debug.DrawRay(_fpCamera.transform.position, _fpCamera.transform.forward * _range, Color.green);
        if(Input.GetMouseButtonDown(0) && _canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;

        if (_ammo.GetCurrentAmmo() != 0)
        {
            _ammo.DecreaseCurrentAmmo();
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

        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _range))
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