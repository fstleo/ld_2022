using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float MaxSize = 14f;
    public float MinSize = 10f;
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
        float currentSize = GetComponent<Camera>().orthographicSize;
        Vector3 cameraPos = gameObject.transform.position;
        Vector3 playerPos = playerObj.transform.position;
        float distance = Vector3.Distance(cameraPos, playerPos) - 8f;
        cameraPos = Vector3.Lerp(cameraPos, playerPos, DelayFactor*Time.deltaTime);
        cameraPos.y = 8;

        float sizeTagget = Mathf.Lerp(MinSize, MaxSize, distance);
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentSize, sizeTagget, DelayFactor * Time.deltaTime);

        gameObject.transform.position = cameraPos;
    }
}
