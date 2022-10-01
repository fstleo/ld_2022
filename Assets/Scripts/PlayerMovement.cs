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

        _rigidbody.AddForce(input * (_speed * Time.deltaTime), ForceMode.Acceleration);
        
        var position = Position;
        _transform.forward = _rigidbody.velocity;
    }
}
