public class PauseMenu : Menu
{
    public void BackToGame()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.Return();
    }
    
    public void BackToMainMenu()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.ToMainMenu();
    }

    public void OnExit()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.Exit();
    }
}