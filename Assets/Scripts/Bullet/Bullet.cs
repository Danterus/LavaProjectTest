using System;
using Infrastructure;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const int EnemyLayer = 8;
    private BulletSettings _bulletSettings;
    private EnemyController _enemyController;
    private float _movementSpeed;
    private float _hitPower;

    private Vector3 _targetDirection;
    private Vector3 _originPosition;
    private Vector3 _movementVector;
    
    private bool _isMoving = false;
    
    public void InitBullet(BulletSettings bulletSettings, EnemyController enemyController, Vector3 position,
        Vector3 direction)
    {
        _bulletSettings = bulletSettings;
        _enemyController = enemyController;

        _movementSpeed = _bulletSettings.GetSpeed();
        _hitPower = _bulletSettings.GetPushPower();
        
        transform.localScale = Vector3.one * _bulletSettings.GetSizeScale();
        transform.position = _originPosition = position;
        
        _targetDirection = direction;
        _movementVector = (_targetDirection - transform.position).normalized;
        _isMoving = true;
    }

    private void FixedUpdate()
    {
        Move();
        if (Vector3.Distance(transform.position, _originPosition) >= 20f) 
            DeactivateBullet();
    }

    private void Move()
    {
        if (_isMoving)
        {
            var transformPosition = transform.position;
            transformPosition += _movementVector * _movementSpeed * Time.fixedDeltaTime;
            transform.position = transformPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == EnemyLayer)
        {
            Enemy e = _enemyController.GetEnemyByRagdollPartCollider(other);
            e.SetRagdolling(other,(_targetDirection - transform.position).normalized,_hitPower);
        }

        DeactivateBullet();
    }

    private void DeactivateBullet()
    {
        _isMoving = false;
        gameObject.SetActive(false);
    }
}
