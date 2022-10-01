public class PauseMenu : Menu
{
    public void BackToGame()
    {
        Game.Return();
    }
    
    public void BackToMainMenu()
    {
        Game.ToMainMenu();
    }

    public void OnExit()
    {
        Game.Exit();
    }
}