using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    public GameObject cameraPos;
    public GMR gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "FlyEnemy" && other.gameObject.name == "Boss")
        {
            cameraPos.GetComponent<CameraPosing>().isAttack = true;
            cameraPos.GetComponent<CameraPosing>().curTime = 0;
            gm.bossDetected = false;
        }
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "FlyEnemy" && other.gameObject.name != "Boss")
        {
            cameraPos.GetComponent<CameraPosing>().isAttack = true;
            cameraPos.GetComponent<CameraPosing>().curTime = 0;
        }
    }
}
