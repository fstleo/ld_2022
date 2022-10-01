using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotation : MonoBehaviour
{
    private Transform _tform;
    private Quaternion _rotationSpeed;
    [SerializeField]
    private float _maxRotationSpeed = 60; 
    
    private void Awake()
    {
        _tform = transform;
        _rotationSpeed = Quaternion.Euler(
            Random.Range(-_maxRotationSpeed/2,_maxRotationSpeed/2) * Time.fixedDeltaTime,
            Random.Range(-_maxRotationSpeed/2,_maxRotationSpeed/2) * Time.fixedDeltaTime,
            Random.Range(-_maxRotationSpeed/2,_maxRotationSpeed/2) * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        _tform.rotation *= _rotationSpeed;
    }
}
