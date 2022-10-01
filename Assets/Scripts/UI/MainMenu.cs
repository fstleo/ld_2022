using UnityEngine;


public class MainMenu : MonoBehaviour
{
    private Game _game;
    
    public void OnStartGameClick()
    {
        _game.Start();
    }

    public void OnExit()
    {
        _game.Exit();
    }
}
