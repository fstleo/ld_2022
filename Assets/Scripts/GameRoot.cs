using System;
using UnityEngine;

public class GameRoot : Root
{

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private ShipMovement _shipMovement;
    [SerializeField] private PartsHolder _partsHolder;
    [SerializeField] private ShipExplosionListener _shipExplosionListener;
    
    [SerializeField] private Bounds _bounds;
    [SerializeField] private MapSpawner _mapSpawner;
    
    protected override void Initialize()
    {
        var blast = new Blast();
        new PlayerInExplosionChecker(blast, _playerMovement, GameInstance);
        
        _shipMovement.Init(blast);
        _partsHolder.Init(blast);
        _shipExplosionListener.Init(blast);
        // _mapSpawner.Init(_shipMovement);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_bounds.center, _bounds.size);
    }
    
    private void Update()
    {
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

