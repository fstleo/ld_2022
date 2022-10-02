public class MusicRoot : Root
{
    private static DJ _musicDJ;
    protected override void Initialize()
    {
        _musicDJ ??= new DJ(GameInstance);
    }
}