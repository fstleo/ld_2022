using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Part : MonoBehaviour
{
    public event Action<Part> Collected;

    [SerializeField] private Rigidbody _rbody;
    [SerializeField] private float _minThrowVelocity;
    [SerializeField] private float _maxThrowVelocity;
    [SerializeField] private float _throwAngleDelta;

    public void Throw(Vector3 direction)
    {
        _rbody.AddForce(Quaternion.Euler(0,Random.Range(-_throwAngleDelta,_throwAngleDelta),0) * direction * Random.Range(_minThrowVelocity, _maxThrowVelocity), ForceMode.Impulse);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected?.Invoke(this);   
        }
    }
    
}