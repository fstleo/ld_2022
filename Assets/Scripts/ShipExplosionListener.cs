using UnityEngine;

public class ShipExplosionListener : MonoBehaviour
{
    private Blast _blast;
    private Transform _transform;
    
    public void Init(Blast blast)
    {
        _transform = transform;
        _blast = blast;
    }

    public void OnExplosionEvent()
    {
        _blast?.Explode(_transform.position);
    }
}