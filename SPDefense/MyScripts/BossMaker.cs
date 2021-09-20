using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMaker : MonoBehaviour
{
    public bool monsterAllDie;
    public bool bossDie;
    public float enemyCurTime;
    public float enemyCoolTime;
    public float stageCurTime;
    public float stageCoolTime;
    public GameObject normalMonster;
    public GameObject tankerMonster;
    public GameObject speedMonster;
    public GameObject flyMonster;
    public GameObject hpBar;
    public List<GameObject> activeEnemys;
    public List<GameObject> createEnemys;
    public List<GameObject> enemys;
    public GMR gameManager;
    public EnemySummoner summon;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GMR>();
        summon = GameObject.Find("EnemyMakers").GetComponent<EnemySummoner>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                enemys.Add(normalMonster);
            }
            else if (i == 1)
            {
                enemys.Add(tankerMonster);
            }
            else if (i == 2)
            {
                enemys.Add(speedMonster);
            }
            else
            {
                enemys.Add(flyMonster);
            }
            GameObject enemyIns = Instantiate(enemys[i], transform.position, transform.rotation) as GameObject;
            enemyIns.name = "Boss";
            enemyIns.transform.GetChild(0).transform.localScale = enemyIns.transform.GetChild(0).transform.localScale * 3;
            createEnemys.Add(enemyIns);
            if (i == 3)
            {
                enemyIns.GetComponent<FlyMonsterController>().startPos = transform;
                enemyIns.GetComponent<FlyMonsterController>().eMaker = gameObject;
                enemyIns.GetComponent<FlyMonsterController>().bossMaker = gameObject;
                enemyIns.SetActive(false);
            }
            else
            {
                enemyIns.GetComponent<EnemyController>().startPos = transform;
                enemyIns.GetComponent<EnemyController>().eMaker = gameObject;
                enemyIns.GetComponent<EnemyController>().bossMaker = gameObject;
                enemyIns.SetActive(false);
            }
        }
    }


    void Update()
    {
        if (activeEnemys.Count < 1 && monsterAllDie && !transform.parent.GetComponentInParent<EnemySummoner>().stagePlaying)
        {
            bossDie = true;
            monsterAllDie = false;
        }
        if (activeEnemys.Count > 0)
        {
            bossDie = false;
            monsterAllDie = true;
        }
        if(gameManager.stageNum != summon.bossStage)
        {
            bossDie = true;
        }
        else 
        {
            bossDie = false;
        }
    }
}
