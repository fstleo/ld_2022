using System;
using UnityEngine;

public class Game
{
    private GameState _state;

    public GameState State
    {
        get => _state;
        private set
        {
            if (_state == value)
            {
                return;
            }
            _state = value;
            GameStateChange?.Invoke(value);
        }
    }

    public event Action<GameState> GameStateChange;
    
    public void Start()
    {
        Time.timeScale = 1f;
        State = GameState.Game;
    }

    public void ToMainMenu()
    {
        State = GameState.MainMenu;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        State = GameState.Pause;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        State = GameState.GameOver;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Return()
    {
        Time.timeScale = 1f;
        State = GameState.Game;
    }
}