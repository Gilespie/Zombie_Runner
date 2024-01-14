using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHitPoints = 100;
    private float _currentHitPoints;

    private void Start()
    {
        _currentHitPoints = _maxHitPoints;
    }

    public void TakeDamage(float amount)
    {
        _currentHitPoints -= Mathf.Abs(amount);

        if(_currentHitPoints <= 0)
        {
            _currentHitPoints = 0;
            Destroy(gameObject);
        }
    }
}