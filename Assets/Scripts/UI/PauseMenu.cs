using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Game _game;

    public void BackToGame()
    {
        _game.Return();
    }
    
    public void BackToMainMenu()
    {
        _game.ToMainMenu();
    }

    public void OnExit()
    {
        _game.Exit();
    }
    
}