using UnityEngine;

public class Root : MonoBehaviour
{
    private Game _game;

    private void Awake()
    {
        _game = new Game();
        var sceneSwitcher = new SceneSwitcher(_game);
    }

    private void Update()
    {
        _game.Tick();
    }
}