using System;
using UnityEngine;
using UnityEngine.AI;

public class GameRoot : Root
{
    private Blast _blast;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private NavMeshAgent _shipMeshAgent;
    
    [SerializeField] private Bounds _bounds;
    
    [SerializeField]
    private PauseMenu _pauseMenu;
    
    [SerializeField]
    private GameMenu _gameMenu;

    [SerializeField]
    private GameOverMenu _gameOverMenu;

    protected override void Initialize()
    {
        InitializeMenu();
        _blast = new Blast(10f);
        new PlayerInExplosionChecker(_blast, _playerMovement, GameInstance);
        new ShipMovement(_shipMeshAgent, _blast, _bounds);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_bounds.center, _bounds.size);
    }

    private void InitializeMenu()
    {
        _pauseMenu.Init(GameInstance);
        _gameMenu.Init(GameInstance);
        _gameOverMenu.Init(GameInstance);
    }

    private void Update()
    {
        _blast.Tick();

        if (!Input.GetButtonDown("Cancel"))
        {
            return;
        }
        switch (GameInstance.State)
        {
            case GameState.Pause:
                GameInstance.Return();
                break;
            case GameState.Game:
                GameInstance.Pause();
                break;
            case GameState.MainMenu:
                GameInstance.Exit();
                break;
            case GameState.GameOver:
                GameInstance.ToMainMenu();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }
}