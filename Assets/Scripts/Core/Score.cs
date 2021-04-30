using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _amountOfTreasure;
    [SerializeField] private TextMeshProUGUI _text;

    public event Action TreasuresCollected;
    
    private int _collectedTreasure = 0;

    private const string GOAL = "Find treasures ";

    private void Start()
    {
        RefreshText();
    }

    public void Increase()
    {
        _collectedTreasure++;
        if(_collectedTreasure == _amountOfTreasure)
        {
            TreasuresCollected?.Invoke();
        }
        RefreshText();
    }

    private void RefreshText()
    {
        _text.SetText($"{GOAL}{_collectedTreasure} - {_amountOfTreasure}");
    }

}
