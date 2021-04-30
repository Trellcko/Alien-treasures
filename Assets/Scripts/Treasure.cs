using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Loot
{
    private Score _score;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
    }

    public override void Effect()
    {
        _score.Increase();
    }
}
