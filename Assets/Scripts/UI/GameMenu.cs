using System;
using TMPro;
using UnityEngine;

public class GameMenu : Menu
{
    [SerializeField] private TextMeshProUGUI _scores;

    private void Update()
    {
        _scores.text = ScoresHolder.Scores.ToString();
    }

    public void Pause()
    {
        Game.Pause();
    }
}