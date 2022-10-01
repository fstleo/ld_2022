using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartRotation : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Random.rotation;
    }
}
