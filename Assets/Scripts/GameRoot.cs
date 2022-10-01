using System;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private Blast _blast;

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField]
    private PauseMenu _pauseMenu;
    
    [SerializeField]
    private GameMenu _gameMenu;

    [SerializeField]
    private GameOverMenu _gameOverMenu;

    
    private void Awake()
    {
        _blast = new Blast(10f);
        new PlayerInExplosionChecker(_blast, _playerMovement, Root.GameInstance);
        _pauseMenu.Init(Root.GameInstance);
        _gameMenu.Init(Root.GameInstance);
        _gameOverMenu.Init(Root.GameInstance);
    }

    private void Update()
    {
        _blast.Tick();

        if (!Input.GetButtonDown("Cancel"))
        {
            return;
        }
        switch (Root.GameInstance.State)
        {
            case GameState.Pause:
                Root.GameInstance.Return();
                break;
            case GameState.Game:
                Root.GameInstance.Pause();
                break;
            case GameState.MainMenu:
                Root.GameInstance.Exit();
                break;
            case GameState.GameOver:
                Root.GameInstance.ToMainMenu();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


    }
}