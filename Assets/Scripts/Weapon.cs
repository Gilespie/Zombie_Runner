using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _fpCamera;
    [SerializeField] private ParticleSystem _muzzleFlashPS;
    [SerializeField] private GameObject _hitImpactPS;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _damage = 38f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
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
            
            Destroy(impactFX, 1f);
        }
    }
}