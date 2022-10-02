using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Part : MonoBehaviour
{
    public event Action<Part> Collected;

    [SerializeField] private Collider _trigger;
    [SerializeField] private Rigidbody _rbody;
    [SerializeField] private float _minThrowVelocity;
    [SerializeField] private float _maxThrowVelocity;
    [SerializeField] private float _throwAngleDelta;
    [SerializeField] private LineRenderer _lineRenderer;

    private bool _eligibleForCollect;
    
    private SpringJoint _joint;
    
    
    public void Throw(Vector3 direction)
    {
        _rbody.AddForce(Quaternion.Euler(0,Random.Range(-_throwAngleDelta,_throwAngleDelta),0) * direction * Random.Range(_minThrowVelocity, _maxThrowVelocity), ForceMode.Impulse);
    }

    private void Update()
    {
        if (_eligibleForCollect)
        {
            _lineRenderer.SetPosition(0, _joint.transform.position);
            _lineRenderer.SetPosition(1, transform.position);
        }
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
            _trigger.enabled = false;
            _lineRenderer.positionCount = 2;
        }

        if (_eligibleForCollect && other.CompareTag("Spaceship"))
        {
            Destroy(_joint);
            Collected?.Invoke(this);
        }
    }
    
}