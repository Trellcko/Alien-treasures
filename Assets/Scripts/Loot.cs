using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Loot : MonoBehaviour
{

    public abstract void Effect();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement _))
        {
            Effect();
            Destroy(gameObject);
        }
    }

}
