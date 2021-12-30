using System;
using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private const string IsRunning = "IsRunning";
    
    [SerializeField] private Animator _animator;

    private static readonly int Running = Animator.StringToHash(IsRunning);

    private bool _isIkActive = false;
    private Vector3 _aimTarget;
    
    public void SetRunning(bool val = true)
    {
        if (_isIkActive) StopShooting();
        _animator.SetBool(Running,val);
    }

    public void SetShooting(Vector3 targetPosition)
    {
        _isIkActive = true;
        SetRotation(targetPosition);
        _aimTarget = targetPosition;

    }

    public void StopShooting()
    {
        _isIkActive = false;
    }

    private void SetRotation(Vector3 target)
    {
        var lookPos = target - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        IkHandAim();
    }

    private void IkHandAim()
    {
        if (_isIkActive)
        {
            _animator.SetLookAtWeight(1);
            _animator.SetLookAtPosition(_aimTarget);

            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand,_aimTarget);
            _animator.SetIKRotation(AvatarIKGoal.RightHand,Quaternion.identity);
        }
        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 
            _animator.SetLookAtWeight(0);
        }
    }
}