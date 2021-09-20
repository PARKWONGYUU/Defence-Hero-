using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public GMR gm;
    public GameObject bulletMaker;
    public bool isAttack;
    public Vector2 touchPos;
    public Vector3 touchDir;
    public float newPosZ;
    public float newPosX;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
    }

    void Update()
    {
        if (gm.mode == GMR.PLAYERMODE.Attack)
        {
            if (Input.touchCount > 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    touchPos = Input.GetTouch(0).position;
                    newPosZ = touchPos.y / Screen.height;
                    newPosX = touchPos.x / Screen.width;
                    if (newPosX >= 0.25f)
                    {
                        touchDir = new Vector3((newPosX * 59.5f) - 33.75f, 0.5f, newPosZ * 27.5f - 13.75f);
                        transform.LookAt(touchDir);
                    }
                }
            }
        }
    }
}
