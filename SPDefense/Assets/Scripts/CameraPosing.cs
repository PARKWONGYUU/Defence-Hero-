using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosing : MonoBehaviour
{
    public bool isAttack;
    public bool isAttack2;
    public bool isAttack3;
    public bool isSaved;
    public bool isSaved2;
    public Transform cameraPos;
    public float curTime;
    public float coolTime = 1f;
    public float curTime2;
    public float coolTime2 = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        if(!isSaved && isAttack && !isSaved2)
        {
            cameraPos.position = transform.position;
            isSaved = true;
        }
        transform.position = Camera.main.transform.position;
        if (isAttack)
        {
            Camera.main.transform.position = new Vector3(cameraPos.transform.position.x + Random.Range(-0.5f, 0.5f), cameraPos.transform.position.y, cameraPos.transform.position.z + Random.Range(-0.5f, 0.5f));
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                isAttack = false;
                curTime = 0;
                isSaved = false;
                Camera.main.transform.position = cameraPos.position;
            }
        }
        if (!isSaved && isAttack2)
        {
            cameraPos.position = transform.position;
            isSaved = true;
        }
        if (isAttack2)
        {
            Camera.main.transform.position = new Vector3(cameraPos.transform.position.x + Random.Range(-0.05f, 0.05f), cameraPos.transform.position.y, cameraPos.transform.position.z + Random.Range(-0.05f, 0.05f));
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                isAttack2 = false;
                curTime = 0;
                isSaved = false;
                Camera.main.transform.position = cameraPos.position;
            }
        }

        if (!isSaved2 && isAttack3 && !isSaved)
        {
            cameraPos.position = transform.position;
            isSaved = true;
        }
        if (isAttack3 && isSaved2)
        {
            Camera.main.transform.position = new Vector3(cameraPos.transform.position.x + Random.Range(-0.01f, 0.01f), cameraPos.transform.position.y, cameraPos.transform.position.z + Random.Range(-0.01f, 0.01f));
            curTime2 += Time.deltaTime;
            if (curTime2 > coolTime2)
            {
                isAttack3 = false;
                curTime2 = 0;
                isSaved2 = false;
                Camera.main.transform.position = cameraPos.position;
            }
        }
    }

}
