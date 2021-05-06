using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedFloor : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private SpikedFloorAnimator _animator;

    private bool _someOneAboveMe = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_someOneAboveMe == false && collision.TryGetComponent(out Health healt))
        {
            healt.TakeDamage(_damage);
            _animator.PlayTrapAnimation();
            _someOneAboveMe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_someOneAboveMe == true)
        {
            _someOneAboveMe = false;
            _animator.PlayHideAnimation();
        }
    }

}
