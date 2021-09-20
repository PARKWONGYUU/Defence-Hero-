using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    public GameObject cameraPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "FlyEnemy")
        {
            cameraPos.GetComponent<CameraPosing>().isAttack = true;
            cameraPos.GetComponent<CameraPosing>().curTime = 0;
        }
    }
}
