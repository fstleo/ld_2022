public class MainMenu : Menu
{
    public void OnStartGameClick()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.ShowTutorial();
    }

    public void OnExit()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.Exit();
    }
}
