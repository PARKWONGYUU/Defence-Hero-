using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJammer : MonoBehaviour
{
    public int itemNum = 0;
    public float curTime;
    public float coolTime = 3.0f;

    public List<GameObject> passEnemys;
    void Start()
    {

    }

    void Update()
    {
        if (passEnemys.Count > 0)
        {
            curTime += Time.deltaTime;
            if (curTime >= coolTime)
            {
                for (int i = 0; i < passEnemys.Count; i++)
                {
                    passEnemys[i].GetComponent<FlyMonsterController>().transform.position = new Vector3(Random.Range(30, 40), 1, Random.Range(-7, 7));
                    passEnemys[i].GetComponent<FlyMonsterController>().transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                curTime = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "FlyEnemy")
        {
            other.gameObject.GetComponent<FlyMonsterController>().hyperJammer = gameObject;
            passEnemys.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "FlyEnemy")
        {
            passEnemys.Remove(other.gameObject);
        }
    }
}
