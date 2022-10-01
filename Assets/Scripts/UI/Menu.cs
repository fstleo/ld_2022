using System;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] private GameState _showOnState;
    private Game _game;

    private GameObject _gameObject;

    protected Game Game
    {
        get
        {
            if (_game == null)
            {
                Debug.LogError($"Menu {gameObject.name} wasn't initialized");
            }
            return _game;
        }
    }
    
    private void OnDestroy()
    {
        _game.GameStateChange -= GameStateChanged;
    }

    public void Init(Game game)
    {
        _gameObject = gameObject;
        _game = game;
        _game.GameStateChange += GameStateChanged;
        GameStateChanged(game.State);
    }

    private void GameStateChanged(GameState obj)
    {
        _gameObject.SetActive(_showOnState == obj);
    }
}