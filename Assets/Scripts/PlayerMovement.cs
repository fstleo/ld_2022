using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rigidbody;
    

    private void Update()
    {
        var inputY = Input.GetAxis("Vertical");
        var inputX = Input.GetAxis("Horizontal");

        var input = new Vector3(inputX, inputY, 0);

        _rigidbody.AddForce(input * (_speed * Time.deltaTime), ForceMode.Acceleration);
    }
}
