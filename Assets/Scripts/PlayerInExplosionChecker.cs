using UnityEngine;

public class PlayerInExplosionChecker
{
    private readonly Blast _blast;
    private readonly PlayerMovement _player;
    private readonly Game _game;

    private RaycastHit[] _raycastHits;

    private LayerMask _obstaclesLayerMask;
    public PlayerInExplosionChecker(Blast blast, PlayerMovement player, Game game)
    {
        _blast = blast;
        _player = player;
        _game = game;
        _obstaclesLayerMask = LayerMask.GetMask("Obstacles");
        blast.Explosion += CheckPlayer;
    }

    private void CheckPlayer()
    {
        bool hitSomething = Physics.Raycast(_blast.Position, _player.Position - _blast.Position,
            (_player.Position - _blast.Position).magnitude, _obstaclesLayerMask);  
        if (!hitSomething)
        {
            // _game.GameOver();
        }
    }
}