using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummoner : MonoBehaviour
{
    public GMR gm;
    public float enemyCurTime;
    public float enemyCoolTime;
    public int ran = 1;
    public int enemyType;
    public int bossType;
    public int tempEnemyType;
    public int nullCnt = 0;
    public int bossStage = 10;
    public bool nullCntStop;
    public List<EnemyMaker> eMakers;
    public BossMaker bossMaker;
    public UIManager UI;
    public EffectsManager em;

    public bool stagePlaying = false;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            eMakers.Add(GameObject.Find(string.Format("EnemyMaker_{0}", i)).GetComponent<EnemyMaker>());
        }
    }

    void Update()
    {
        if (gm.stageStart)
        {
            if(gm.stageNum <= 10)
            {
                ran = 1;
            }
            else if (gm.stageNum <= 20)
            {
                ran = Random.Range(1, 3);
            }
            else if (gm.stageNum <= 40)
            {
                ran = Random.Range(1, 4);
            }
            else if (gm.stageNum > 40)
            {
                ran = Random.Range(1, 5);
            }
            enemyType = ran * 3;
            bossType = ran - 1;
            tempEnemyType += enemyType - 3;
            gm.stageStart = false;
            stagePlaying = true;
        }

        if (stagePlaying)
        {
            enemyCurTime += Time.deltaTime;
            if(enemyCurTime >= enemyCoolTime / 2)
            {
                em.summonEffects.SetActive(true);
            }
            if (enemyCurTime >= enemyCoolTime)
            {
                UI.stageTextOn = false;
                enemyCurTime = 0;
                if (enemyType <= 3)
                {
                    enemyType--;
                    for (int i = 0; i < eMakers.Count; i++)
                    {
                        eMakers[i].createEnemys[enemyType].SetActive(true);
                        eMakers[i].activeEnemys.Add(eMakers[i].createEnemys[enemyType]);
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().enemyHP = gm.stageNum * 200;                            //Normal형 적의 능력치 설정
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().maxEnemyHP = gm.stageNum * 200;
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().bulletDmg = UI.bulletDmg;
                    }
                    if(gm.stageNum == bossStage && enemyType == 0)
                    {
                        gm.bossDetected = true;
                        bossMaker.createEnemys[bossType].SetActive(true);
                        bossMaker.activeEnemys.Add(bossMaker.createEnemys[bossType]);
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().enemyHP = gm.stageNum * 200 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().maxEnemyHP = gm.stageNum * 200 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().bulletDmg = UI.bulletDmg;
                        bossStage += 10;
                    }
                }
                else if (enemyType <= 6)
                {
                    enemyType--;
                    for (int i = 0; i < eMakers.Count; i++)
                    {
                        eMakers[i].createEnemys[enemyType].SetActive(true);
                        eMakers[i].activeEnemys.Add(eMakers[i].createEnemys[enemyType]);
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().enemyHP = gm.stageNum * 400;                         //Tanker형 적의 능력치 설정
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().maxEnemyHP = gm.stageNum * 400;
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().bulletDmg = UI.bulletDmg;
                    }
                    if (gm.stageNum == bossStage && enemyType == 3)
                    {
                        gm.bossDetected = true;
                        bossMaker.createEnemys[bossType].SetActive(true);
                        bossMaker.activeEnemys.Add(bossMaker.createEnemys[bossType]);
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().enemyHP = gm.stageNum * 400 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().maxEnemyHP = gm.stageNum * 400 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().bulletDmg = UI.bulletDmg;
                        bossStage += 10;
                    }
                }
                else if (enemyType <= 9)
                {
                    enemyType--;
                    for (int i = 0; i < eMakers.Count; i++)
                    {
                        eMakers[i].createEnemys[enemyType].SetActive(true);
                        eMakers[i].activeEnemys.Add(eMakers[i].createEnemys[enemyType]);
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().enemyHP = gm.stageNum * 160;                           //speed형 적의 능력치 설정
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().maxEnemyHP = gm.stageNum * 160;
                        eMakers[i].createEnemys[enemyType].GetComponent<EnemyController>().bulletDmg = UI.bulletDmg;
                    }
                    if (gm.stageNum == bossStage && enemyType == 6)
                    {
                        gm.bossDetected = true;
                        bossMaker.createEnemys[bossType].SetActive(true);
                        bossMaker.activeEnemys.Add(bossMaker.createEnemys[bossType]);
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().enemyHP = gm.stageNum * 160 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().maxEnemyHP = gm.stageNum * 160 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<EnemyController>().bulletDmg = UI.bulletDmg;
                        bossStage += 10;
                    }
                }
                else if (enemyType <= 12)
                {
                    enemyType--;
                    for (int i = 0; i < eMakers.Count; i++)
                    {
                        eMakers[i].createEnemys[enemyType].SetActive(true);
                        eMakers[i].activeEnemys.Add(eMakers[i].createEnemys[enemyType]);
                        eMakers[i].createEnemys[enemyType].GetComponent<FlyMonsterController>().enemyHP = gm.stageNum * 140;                           //Fly형 적의 능력치 설정
                        eMakers[i].createEnemys[enemyType].GetComponent<FlyMonsterController>().maxEnemyHP = gm.stageNum * 140;
                        eMakers[i].createEnemys[enemyType].GetComponent<FlyMonsterController>().bulletDmg = UI.bulletDmg;
                    }
                    if (gm.stageNum == bossStage && enemyType == 9)
                    {
                        gm.bossDetected = true;
                        bossMaker.createEnemys[bossType].SetActive(true);
                        bossMaker.activeEnemys.Add(bossMaker.createEnemys[bossType]);
                        bossMaker.createEnemys[bossType].GetComponent<FlyMonsterController>().enemyHP = gm.stageNum * 140 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<FlyMonsterController>().maxEnemyHP = gm.stageNum * 140 * bossStage;
                        bossMaker.createEnemys[bossType].GetComponent<FlyMonsterController>().bulletDmg = UI.bulletDmg;
                        bossStage += 10;
                    }
                }
            }
            if (enemyType == tempEnemyType)
            {
                stagePlaying = false;
                tempEnemyType = 0;
                em.summonEffects.SetActive(false);
            }
        }

        if (nullCnt == 10 && !stagePlaying && !gm.stageStart && !gm.bossDetected)
        {
            gm.stageEnd = true;
            nullCnt = 0;
            gm.gold += 100 * ((gm.stageNum / 10) + 1);
            gm.jewelry += 1;
        }
    }
}
