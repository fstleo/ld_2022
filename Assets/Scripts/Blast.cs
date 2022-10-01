using System;
using UnityEngine;

public class Blast
{
    public event Action Explosion;

    public float BlastTimer { get; private set; } = 1f;
    public Vector3 Position { get; private set; } = new Vector3(0, 0,-0.1f);

    public void Tick()
    {
        BlastTimer -= Time.deltaTime;
        if (BlastTimer < 0)
        {
            BlastTimer = 1f;
            Debug.Log("Boom");
            Explosion?.Invoke();
        }
    }
}