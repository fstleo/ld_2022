public class GameMenu : Menu
{
    public void Pause()
    {
        SoundManager.PlaySound(SoundId.Click);
        Game.Pause();
    }
}