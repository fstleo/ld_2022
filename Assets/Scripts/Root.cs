using UnityEngine;

public class Root : MonoBehaviour
{
    public static Game GameInstance
    {
        get;
        private set;
    }
    
    [SerializeField]
    private MainMenu _mainMenu;
    
    private void Awake()
    {
        if (GameInstance == null)
        {
            GameInstance = new Game();
            var sceneSwitcher = new SceneSwitcher(GameInstance);
        }
        _mainMenu.Init(GameInstance);
    }
}