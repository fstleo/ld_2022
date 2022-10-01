using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PartsCollector : MonoBehaviour
{
    public event Action PartCollected;
}


public class ShipMovement
{
    private NavMeshAgent _agent;
    private readonly Bounds _bounds;

    public ShipMovement(NavMeshAgent agent, Blast blast,
        Bounds bounds)
    {
        _agent = agent;
        _bounds = bounds;
        blast.Explosion += OnExplosion;
        _agent.destination = agent.transform.position;
    }

    private Vector3 GetRandomPointInBounds()
    {
        return new Vector3(
            Random.Range(_bounds.min.x, _bounds.max.x),
            Random.Range(0, 0),
            Random.Range(_bounds.min.z, _bounds.max.z));
    }

    private void OnExplosion()
    {
        var nextPoint = GetRandomPointInBounds();
        if (NavMesh.SamplePosition(nextPoint, out var hit, 100, NavMesh.AllAreas))
        {
            _agent.destination = hit.position;
        }
    }
}

public class Part : MonoBehaviour
{
    public event Action<Part> Collected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected?.Invoke(this);   
        }
    }
    
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rigidbody;

    public Vector3 Position => _rigidbody.position;
    
    private void Update()
    {
        var inputY = Input.GetAxis("Vertical");
        var inputX = Input.GetAxis("Horizontal");

        var input = new Vector3(inputX, 0,inputY);

        _rigidbody.AddForce(input * (_speed * Time.deltaTime), ForceMode.Acceleration);
    }
}
