using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected LayerMask _enemyLayer;

    public abstract void Attack();

}
