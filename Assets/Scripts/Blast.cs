using System;
using UnityEngine;

public class Blast
{
    public event Action Explosion;

    private readonly float _timeBetweenBlasts;
    public float BlastTimer { get; private set; }
    public Vector3 Position { get; private set; } = new Vector3(0, 0,-0.1f);

    public Blast(float blastTimer = 10f)
    {
        BlastTimer = blastTimer;
        _timeBetweenBlasts = blastTimer;
    }
    
    public void Tick()
    {
        BlastTimer -= Time.deltaTime;
        if (BlastTimer < 0)
        {
            BlastTimer = _timeBetweenBlasts;
            Debug.Log("Boom");
            Explosion?.Invoke();
        }
    }
}