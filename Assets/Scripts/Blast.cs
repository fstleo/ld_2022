using System;
using UnityEngine;

public class Blast
{
    public event Action<Vector3> Explosion;
    
    public void Explode(Vector3 position)
    {
        Debug.Log("Boom");
        Explosion?.Invoke(position);
    }
}