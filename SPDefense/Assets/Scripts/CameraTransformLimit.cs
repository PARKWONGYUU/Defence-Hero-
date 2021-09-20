using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformLimit : MonoBehaviour
{
    public Camera cameraPos;
    public GMR gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
    }

    void Update()
    {
        if (gm.mode == GMR.PLAYERMODE.Create)
        {
            if (transform.position.x < -10)
            {
                cameraPos.transform.position = new Vector3(-10, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 10)
            {
                cameraPos.transform.position = new Vector3(10, transform.position.y, transform.position.z);
            }
            if (transform.position.z > -5)
            {
                cameraPos.transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            }
            if (transform.position.z < -20)
            {
                cameraPos.transform.position = new Vector3(transform.position.x, transform.position.y, -20);
            }
        }
    }
}
