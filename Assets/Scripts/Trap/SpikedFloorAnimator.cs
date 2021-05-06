using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SpikedFloorAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string GOTCHA = "Gotcha";
    private const string HIDE = "Hide";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayTrapAnimation()
    {
        _animator.SetTrigger(GOTCHA);
    }

    public void PlayHideAnimation()
    {
        _animator.SetTrigger(HIDE);
    }

}
