using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseRange = 5f;

    private NavMeshAgent _nawMeshAgent;
    private float _distanceToTarget = Mathf.Infinity;
    private bool _isProvoke = false;

    private void Start()
    {
        _nawMeshAgent = GetComponent<NavMeshAgent>();    
    }

    
    private void Update()
    {
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);

        if(_isProvoke)
        {
            EngageTarget();
        }
        else if(_distanceToTarget <= _chaseRange)
        {
            _isProvoke = true;
        }

            
        
    }

    private void EngageTarget()
    {
        if(_distanceToTarget >= _nawMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if(_distanceToTarget <= _nawMeshAgent.stoppingDistance)
        {
            Attack();
        }
    }

    private void ChaseTarget()
    {
        _nawMeshAgent.SetDestination(_target.position);
    }

    private void Attack()
    {
        Debug.Log("Hit player!");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}