using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponAnimator : WeaponAnimator
{
    public event Action AttackStarted;
    public event Action AttackFinished;


    public void StartAttacking()
    {
        AttackStarted?.Invoke();
    }

    public void FinishAttacking()
    {
        AttackFinished?.Invoke();
    }
}
