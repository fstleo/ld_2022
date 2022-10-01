using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    private readonly Game _game;

    public SceneSwitcher(Game game)
    {
        _game = game;
        _game.GameStateChange += OnStateChange;
    }

    private void OnStateChange(GameState state)
    {
        if (state == GameState.Game)
        {
            SceneManager.LoadScene("GameScene");
        }

        if (state == GameState.MainMenu)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}