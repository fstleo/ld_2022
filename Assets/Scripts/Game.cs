using System;
using UnityEngine;


public class DJ
{
    private readonly Game _game;
    private GameState _previousState;

    public DJ(Game game)
    {
        _game = game;
        game.GameStateChange += GameStateChange;
    }

    private void GameStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Tutorial:
                break;
            case GameState.MainMenu:
                SoundManager.StartMusic();
                break;
            case GameState.Game when _previousState != GameState.Pause:
                SoundManager.StopMusic();
                SoundManager.StartMusic();
                break;
            case GameState.Game when _previousState == GameState.Pause:
                SoundManager.StartMusic();
                break;
            case GameState.Pause:
                SoundManager.PauseMusic();
                break;
            case GameState.GameOver:
                SoundManager.StopMusic();
                SoundManager.StartMusic();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }

        _previousState = state;
    }
}


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

    public void ShowTutorial()
    {
        State = GameState.Tutorial;
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
        Time.timeScale = 1f;
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