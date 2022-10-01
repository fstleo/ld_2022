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

    private void CheckPlayer(Vector3 blastPosition)
    {
        bool hitSomething = Physics.Raycast(blastPosition, _player.Position - blastPosition,
            (_player.Position - blastPosition).magnitude, _obstaclesLayerMask);  
        if (!hitSomething)
        {
            Debug.Log("Player in explosion!");
            // _game.GameOver();
        }
    }
}