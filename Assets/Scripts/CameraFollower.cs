using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    
    private Transform _target;
    
    public void FollowTarget(Transform target)
    {
        _target = target; 
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
        }
    }
}
