using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SandArea : MonoBehaviour
{
    public int itemNum = 2;
    public float itemSpeedDown = 0.5f;

    public List<GameObject> speedDownEnemys;
    void Start()
    {

    }

    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().sandArea = gameObject;
            speedDownEnemys.Add(other.gameObject);
            other.GetComponent<NavMeshAgent>().speed *= itemSpeedDown;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().sandArea = null;
            speedDownEnemys.Remove(other.gameObject);
            other.GetComponent<NavMeshAgent>().speed /= itemSpeedDown;
        }
    }
}
