using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public bool monsterAllDie;
    public float enemyCurTime;
    public float enemyCoolTime;
    public float stageCurTime;
    public float stageCoolTime;
    public GameObject normalMonster;
    public GameObject tankerMonster;
    public GameObject speedMonster;
    public GameObject flyMonster;
    public List<GameObject> activeEnemys;
    public List<GameObject> createEnemys;
    public List<GameObject> enemys;
    public GMR gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GMR>();
        for (int i = 0; i < 12; i++)
        {
            if(i < 3)
            {
                enemys.Add(normalMonster);
            }
            else if(i < 6)
            {
                enemys.Add(tankerMonster);
            }
            else if(i < 9)
            {
                enemys.Add(speedMonster);
            }
            else 
            {
                enemys.Add(flyMonster);
            }
            GameObject enemyIns = Instantiate(enemys[i], transform.position, transform.rotation) as GameObject;
            enemyIns.name = "Enemy";
            createEnemys.Add(enemyIns);
            if (i > 8)
            {
                enemyIns.GetComponent<FlyMonsterController>().startPos = transform;
                enemyIns.GetComponent<FlyMonsterController>().eMaker = gameObject;
                enemyIns.SetActive(false);
            }
            else
            {
                enemyIns.GetComponent<EnemyController>().startPos = transform;
                enemyIns.GetComponent<EnemyController>().eMaker = gameObject;
                enemyIns.SetActive(false);
            }
        }
    }

    
    void Update()
    {
        if (activeEnemys.Count < 1 && monsterAllDie && !transform.parent.GetComponentInParent<EnemySummoner>().stagePlaying)
        {
            transform.parent.GetComponentInParent<EnemySummoner>().nullCnt++;
            monsterAllDie = false;
        }
        if(activeEnemys.Count > 0)
        {
            monsterAllDie = true;
        }
    }
}
