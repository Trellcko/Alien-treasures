using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool GameEnd { get; private set; }

    [SerializeField] private Health _playerHealth;

    [SerializeField] private Score _score;
    [SerializeField] private GameObject _endMenuUI;
    [SerializeField] private TextMeshProUGUI _text;
    
    private const string LOSE = "Oh no, you lose? Try again!";
    private const string WIN = "Congratulation you Win!";

    private void Start()
    {
        Time.timeScale = 1;
        GameEnd = false;
        _score.TreasuresCollected += Win;
        _playerHealth.Died += Lose;
    }

    private void ActivateMenu(string text)
    {
        _text.SetText(text);
        _endMenuUI.gameObject.SetActive(true);
    }

    private void Lose()
    {
        ActivateMenu(LOSE);
        Time.timeScale = 0;
    }

    private void Win()
    {
        ActivateMenu(WIN);
        Time.timeScale = 0;
    }

}
