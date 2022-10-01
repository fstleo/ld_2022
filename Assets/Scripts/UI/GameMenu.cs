using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private Game _game;

    public void Pause()
    {
        _game.Pause();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
    }
}