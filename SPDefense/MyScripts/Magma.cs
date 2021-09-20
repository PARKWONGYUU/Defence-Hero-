using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    public int itemNum = 0;
    public int itemDmg = 1000;
    public float curTime;
    public float coolTime = 0.2f;
    
    public List<GameObject> dmgEnemys;
    void Start()
    {
        
    }

    void Update()
    {
        if(dmgEnemys.Count > 0)
        {
            curTime += Time.deltaTime;
            if(curTime >= coolTime)
            {
                for (int i = 0; i < dmgEnemys.Count; i++)
                {
                    if (dmgEnemys[i].GetComponent<EnemyController>().enemyHP > 0)
                    {
                        dmgEnemys[i].GetComponent<EnemyController>().enemyHP -= itemDmg;
                    }
                    else
                    {
                        dmgEnemys.Remove(dmgEnemys[i]);
                    }
                }
                curTime = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().magma = gameObject;
            dmgEnemys.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().magma = null;
            dmgEnemys.Remove(other.gameObject);
        }
    }
}
