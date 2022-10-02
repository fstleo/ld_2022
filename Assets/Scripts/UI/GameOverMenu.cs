public class GameOverMenu : Menu
{
    public void Restart()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.Start();
    }

    public void ToMainMenu()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.ToMainMenu();
    }
}