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
    private bool _eligibleForCollect;

    private SpringJoint _joint;
    public void Throw(Vector3 direction)
    {
        _rbody.AddForce(Quaternion.Euler(0,Random.Range(-_throwAngleDelta,_throwAngleDelta),0) * direction * Random.Range(_minThrowVelocity, _maxThrowVelocity), ForceMode.Impulse);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _joint = other.gameObject.AddComponent<SpringJoint>();
            _joint.damper = 100;
            _joint.minDistance = 0.1f;
            _joint.maxDistance = 0.2f;
            _joint.connectedBody = _rbody;
            _eligibleForCollect = true;
        }

        if (_eligibleForCollect && other.CompareTag("Spaceship"))
        {
            Destroy(_joint);
            Collected?.Invoke(this);
        }
    }
    
}