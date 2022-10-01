using System;
using UnityEngine;

public class Part : MonoBehaviour
{
    public event Action<Part> Collected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected?.Invoke(this);   
        }
    }
    
}