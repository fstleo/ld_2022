using UnityEngine;

public abstract class Root : MonoBehaviour
{
    public static Game GameInstance
    {
        get;
        private set;
    }
    
    
    private void Awake()
    {
        if (GameInstance == null)
        {
            GameInstance = new Game();
            var sceneSwitcher = new SceneSwitcher(GameInstance);
        }
        Initialize();
    }

    protected abstract void Initialize();
}