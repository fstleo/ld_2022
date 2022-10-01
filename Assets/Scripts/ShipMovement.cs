using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rbody;

    [SerializeField] private float _maxImpulseForce;
    
    [SerializeField]
    private Transform _leftEngineTransform;

    [SerializeField]
    private Transform _rightEngineTransform;

    public Vector3 Position => _rbody.position;
    
    private float _timer;
    
    public void Init(Blast blast)
    {
        blast.Explosion += OnExplosion;
    }

    private void OnExplosion(Vector3 explosionPosition)
    {
        _timer += Random.Range(0, 0.5f);
    }

    private void FixedUpdate()
    {
        if (_timer < 0)
        {
            return;
        }
        _timer -= Time.fixedDeltaTime;
        var leftEngineThrottle = Random.Range(.9f, 1f)* _maxImpulseForce;
        var rightEngineThrottle = Random.Range(.9f, 1f) * _maxImpulseForce;
        var forward = _rbody.transform.forward;
        _rbody.angularVelocity = new Vector3(0, 0, 0);
        _rbody.AddForceAtPosition(forward * leftEngineThrottle, _leftEngineTransform.position, ForceMode.Acceleration);
        _rbody.AddForceAtPosition(forward * rightEngineThrottle, _rightEngineTransform.position, ForceMode.Acceleration);
    }


}