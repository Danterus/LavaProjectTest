using System;
using UnityEngine;
using UnityEngine.AI;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private HeroAnimator _heroAnimator;
    private float _movementSpeed;
    private Vector3 _target;
    

    private bool _isMoving = false;
    
    public void Init(HeroAnimator animator, float movementSpeed)
    {
        _heroAnimator = animator;
        _movementSpeed = movementSpeed;
        _navMeshAgent.speed = _movementSpeed;
    }

    public void MoveTowards(Vector3 position)
    {
        _target = position;
        _isMoving = true;
    }

    public void StopMovement()
    {
        _isMoving = false;
        _heroAnimator.SetRunning(false);
        _navMeshAgent.ResetPath();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
        _navMeshAgent.ResetPath();
    }

    private void FixedUpdate()
    {
        Move();
        if (Vector3.Distance(_target,transform.position) <= .25f) 
            TargetReached();
    }

    private void TargetReached()
    {
        _isMoving = false;
    }

    private void Move()
    {
        _heroAnimator.SetRunning(_isMoving);
        if (_isMoving)
        {
            _navMeshAgent.destination = _target;
        }
        
    }
}