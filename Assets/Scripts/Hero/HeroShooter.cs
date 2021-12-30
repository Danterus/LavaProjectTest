using System;
using System.Collections;
using Infrastructure;
using UnityEngine;

public class HeroShooter : MonoBehaviour
{
    [SerializeField] private Transform _handPosition;
    private BulletController _bulletController;
    private HeroAnimator _heroAnimator;

    private Vector3 _target;

    private float _reloadSpeed;
    private float _currentReloadTime;

    private bool _isShooting = false;
    private bool _isReloaded => _currentReloadTime >= _reloadSpeed;
    public void Init(BulletController bulletController,HeroAnimator animator, float reloadSpeed)
    {
        _bulletController = bulletController;
        _heroAnimator = animator;
        _reloadSpeed = reloadSpeed;
    }

    public void ShootTowards(Vector3 target)
    {
        _target = target + Vector3.up;
        _heroAnimator.SetShooting(target);
        _isShooting = true;
    }

    public void StopShooting()
    {
        _heroAnimator.StopShooting();
        _isShooting = false;
    }

    private void Update()
    {
        if (_isShooting && _isReloaded)
        {
            MakeShot();
        }
        else
        {
            ReloadShot();
        }
    }

    private void MakeShot()
    {
        _bulletController.SpawnBullet(_handPosition.position,_target);
        _currentReloadTime = 0;

    }

    private void ReloadShot()
    {
        if (_currentReloadTime < _reloadSpeed)
        {
            _currentReloadTime += Time.deltaTime;
        }
        else
        {
            _currentReloadTime = _reloadSpeed;
        }
    }
}