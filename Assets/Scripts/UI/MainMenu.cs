public class MainMenu : Menu
{
    public void OnStartGameClick()
    {
        Game.Start();
    }

    public void OnExit()
    {
        Game.Exit();
    }
}
