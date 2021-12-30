using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    public void ToggleMove(bool val)
    {
        _animator.SetBool(IsRunning,val);
    }

    public void ToggleAnimator(bool val)
    {
        _animator.enabled = val;
    }
}
