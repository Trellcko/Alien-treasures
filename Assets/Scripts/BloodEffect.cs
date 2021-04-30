using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : ParticleEffect
{
    [SerializeField] private Health _healt;

    private void Start()
    {
        _healt.DamageTaken += (float x) => Play();
    }
}
