using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHitPoints = 100;
    private float _currentHitPoint;

    private void Start()
    {
        _currentHitPoint = _maxHitPoints;    
    }

    public void TakeDamage(float amount)
    {
        _currentHitPoint -= Mathf.Abs(amount);

        if(_currentHitPoint <= 0 )
        {
            _currentHitPoint = 0;
            GetComponent<DeathHandler>().HandlerDeath();
        }
    }

    public void RestoreHitPoint(float amount)
    {
        _currentHitPoint += Mathf.Abs(amount);
    }
}