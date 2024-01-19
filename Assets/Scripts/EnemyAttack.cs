using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 30f;
    private PlayerHealth _target;

    void Start()
    {
        _target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(_target != null)
        {
            _target.TakeDamage(_damage);
        }
    }
}