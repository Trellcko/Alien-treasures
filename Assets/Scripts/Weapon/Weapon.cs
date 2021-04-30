using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponAnimator _animator;
    [SerializeField] protected LayerMask _enemyLayer;

    protected bool _isAttacking;
    public abstract void Attack();

}
