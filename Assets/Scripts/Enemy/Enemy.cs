using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<RagdollPart> _ragdollParts;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    
    private EnemyMovement _enemyMovement;

    private bool isAlive = true;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    public void Init(Vector3 position)
    {
        isAlive = true;
        gameObject.SetActive(true);
        ToggleKinematicParts(true);
        _enemyAnimator.ToggleMove(isAlive);
        _enemyMovement.SetPosition(position);
        _enemyAnimator.ToggleAnimator(true);
    }
    
    public void SetRagdolling(Collider col,Vector3 direction,float hitPower)
    {
        isAlive = false;
        _enemyMovement.StopMovement();
        _enemyAnimator.ToggleAnimator(false);
        ToggleKinematicParts(false);
        Rigidbody targetRb = _ragdollParts.Find(x => x.Collider = col).Rigidbody;
        targetRb.AddForce(direction * hitPower,ForceMode.Impulse);

    }

    public bool IsEnemyAlive() => isAlive;

    public bool FindRagdollPart(Collider c)
    {
        return _ragdollParts.FindAll(x => x.Collider == c).Count > 0;
    }

    private void ToggleKinematicParts(bool val)
    {
        foreach (var part in _ragdollParts)
        {
            part.Rigidbody.isKinematic = val;
        }
    }
}