using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tower : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private Transform _playerShootingSpot;

    private Collider _collider;
    public NavMeshSurface GetNavMeshSurface() => _navMeshSurface;
    public Vector3 GetPlayerPosition() => _playerShootingSpot.position;

    private Hero _hero;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void InitTower(Hero hero)
    {
        _hero = hero;
        _collider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _hero.gameObject)
        {
            _hero.SwitchToShooting(GetPlayerPosition());

            _collider.enabled = false;
        }
    }
}
