using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    [SerializeField] private AudioClip _pickUpAudio;
    public abstract void Effect();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement _))
        {
            Effect();
            AudioManager.Instance.PlaySound(_pickUpAudio);
            Destroy(gameObject);
        }
    }

}
