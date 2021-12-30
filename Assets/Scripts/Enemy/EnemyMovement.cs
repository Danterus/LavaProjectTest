using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _movementSpeed;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _navMeshAgent.speed = _movementSpeed;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
        _navMeshAgent.ResetPath();
    }

    public void StopMovement()
    {
        _navMeshAgent.ResetPath();
    }
    
    public void Update()
    {
        RandomMovement();
    }

    private void RandomMovement()
    {
        if (_enemy.IsEnemyAlive())
        {
            if (_navMeshAgent.remainingDistance <= 0.15f)
            {
                _navMeshAgent.destination = transform.position + new Vector3(
                    Random.Range(-5, 5),
                    0,
                    Random.Range(-5, 5)
                );
            }
        }
    }

    
}