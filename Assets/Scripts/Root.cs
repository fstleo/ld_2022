using UnityEngine;

public class Root : MonoBehaviour
{
    private Game _game;
    private Blast _blast;

    [SerializeField] private PlayerMovement _playerMovement;
    
    private void Awake()
    { 
        DontDestroyOnLoad(this);
        _game = new Game();
        var sceneSwitcher = new SceneSwitcher(_game);
        _blast = new Blast();
        new PlayerInExplosionChecker(_blast, _playerMovement, _game);
    }

    private void Update()
    {
        _blast.Tick();
    }
}

