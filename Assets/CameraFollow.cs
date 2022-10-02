using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float DelayFactor = 0.1f;
    private GameObject playerObj = null;


    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 cameraPos = gameObject.transform.position;
        Vector3 playerPos = playerObj.transform.position;
        cameraPos = Vector3.Lerp(cameraPos, playerPos, DelayFactor*Time.deltaTime);
        cameraPos.y = 8;

        gameObject.transform.position = cameraPos;
    }
}
