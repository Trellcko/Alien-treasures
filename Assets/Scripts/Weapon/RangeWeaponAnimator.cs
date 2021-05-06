using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeaponAnimator : WeaponAnimator
{

    public event Action Shooted;

    public void Shoot()
    {
        Shooted?.Invoke();
    }

}
