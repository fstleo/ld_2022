using System;
using UnityEngine;

public class Game
{
    private GameState _state;

    public GameState State
    {
        get => _state;
        set
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

    public void Exit()
    {
        Application.Quit();
    }

    public void Return()
    {
        State = GameState.Game;
    }
}