using UnityEngine;

public class MainMenuRoot : Root
{
    [SerializeField]
    private MainMenu _mainMenu;
    
    protected override void Initialize()
    {
        _mainMenu.Init(GameInstance);
    }
}