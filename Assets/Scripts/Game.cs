using System;
using UnityEngine;

public class Game
{
    public GameState State;

    public event Action<GameState> GameStateChange;
    public event Action Blast;
    
    public float BlastTimer { get; private set; }
    
    public void Start()
    {
        GameStateChange?.Invoke(GameState.Game);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Tick()
    {
        BlastTimer -= Time.deltaTime;
        if (BlastTimer < 0)
        {
            BlastTimer = 10f;
            Blast?.Invoke();
        }
    }
}