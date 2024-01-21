using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseRange = 5f;
    [SerializeField] private float _turnSpeed = 5f;

    private NavMeshAgent _nawMeshAgent;
    private EnemyHealth _enemyHealth;
    private float _distanceToTarget = Mathf.Infinity;
    private bool _isProvoke = false;

    private void Start()
    {
        _nawMeshAgent = GetComponent<NavMeshAgent>();    
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    
    private void Update()
    {
        if(_enemyHealth.IsDead())
        {
            this.enabled = false;
            _nawMeshAgent.enabled = false;
        }

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

    private void OnDamageTaken()
    {
        _isProvoke = true;
    }

    private void EngageTarget()
    {
        FaceToTarget();

        if (_distanceToTarget >= _nawMeshAgent.stoppingDistance)
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
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        _nawMeshAgent.SetDestination(_target.position);
    }

    private void Attack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void FaceToTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}