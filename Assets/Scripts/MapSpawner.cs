using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacles;

    public Vector3Int Position { get; private set; }

    public void Init(Vector3Int position)
    {
        Position = position;
        transform.position = position;
    }

    public void Enter()
    {
        
    }

    public void Leave()
    {
        
    }
}

public class MapSpawner: MonoBehaviour
{
    [SerializeField]
    private GameObject _tilePrefab;
    
    [SerializeField]
    private float _squareSize = 100f;

    [SerializeField]
    private int _mapSize = 100;
    
    private ShipMovement _shipMovement;

    private Bounds _shipBounds;
    private Bounds _mapBounds;
    
    public void Init(ShipMovement shipMovement)
    {
        _shipMovement = shipMovement;
        _shipBounds = new Bounds(Vector3.zero, new Vector3(_squareSize, 1,  _squareSize));
        _mapBounds = _shipBounds;
        _mapBounds.size *= 3;
    }
    
    private void Update()
    {
        if (!_shipBounds.Contains(_shipMovement.Position))
        {
            var delta = (_shipMovement.Position - _shipBounds.center) / _squareSize;
            var nextTileOffset = new Vector3(Mathf.Round(delta.x) * _squareSize,0, Mathf.Round(delta.z) * _squareSize);
            _shipBounds.center += nextTileOffset;
            _mapBounds.center += nextTileOffset;
            
        }
    }


}