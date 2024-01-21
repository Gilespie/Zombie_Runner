using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHitPoints = 100;
    private float _currentHitPoints;
    private bool _isDead = false;

    public bool IsDead()
    {
        return _isDead;
    }

    private void Start()
    {
        _currentHitPoints = _maxHitPoints;
    }

    public void TakeDamage(float amount)
    {
        if (_currentHitPoints == 0) return;

        BroadcastMessage("OnDamageTaken");
        _currentHitPoints -= Mathf.Abs(amount);

        if(_currentHitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(_isDead) return;

        _isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}