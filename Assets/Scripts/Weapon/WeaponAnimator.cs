using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimator : MonoBehaviour
{
    public event Action AttackFinishing;


    private Animator _animator;


    private const string ATTACK = "Attack";
    private const string CANCEL_ATTACK = "CancelAttack";
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAttackAnimation()
    {
        _animator.SetTrigger(ATTACK);
        _animator.ResetTrigger(CANCEL_ATTACK);
    }

    public void FinishAttacking()
    {
        AttackFinishing?.Invoke();
    }

    public void CancelAttackAnimation()
    {
        _animator.SetTrigger(CANCEL_ATTACK);
        _animator.ResetTrigger(ATTACK);
    }

}
