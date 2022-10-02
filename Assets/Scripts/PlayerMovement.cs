using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rigidbody;

    public Vector3 Position => _rigidbody.position;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        var inputY = Input.GetAxis("Vertical");
        var inputX = Input.GetAxis("Horizontal");

        var input = new Vector3(inputX, 0,inputY);

        if (input.sqrMagnitude > 0.01f)
        {
            SoundManager.PlayLoop(SoundId.Hiss);
        }
        else
        {
            SoundManager.StopLoop(SoundId.Hiss);
        }
        _rigidbody.AddForce(input * (_speed * Time.deltaTime), ForceMode.Acceleration);
        
        _transform.forward = _rigidbody.velocity;
    }

    private void OnDestroy()
    {
        SoundManager.StopLoop(SoundId.Hiss);
    }
}
