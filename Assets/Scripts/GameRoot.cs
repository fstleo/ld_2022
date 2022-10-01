using System;
using UnityEngine;
using UnityEngine.AI;

public class GameRoot : Root
{
    private Blast _blast;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private ShipMovement _shipMovement;
    [SerializeField] private PartsHolder _partsHolder;
    
    [SerializeField] private Bounds _bounds;
    
    protected override void Initialize()
    {
        _blast = new Blast(10);
        new PlayerInExplosionChecker(_blast, _playerMovement, GameInstance);
        _shipMovement.Init(_blast);
        _partsHolder.Init(_blast);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_bounds.center, _bounds.size);
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