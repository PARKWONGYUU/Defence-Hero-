using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public EnemySummoner summon;
    public GameObject attackRange;
    public int towerNum;
    public int attackDmg;
    public float attackCurTime;
    public float attackSpeed;
    public bool isAttack;
    public float attackingCurTime;
    public float attackingCoolTime;
    public int upgradeDmg;
    public float upgradeSpeed;
    public int dmgPrice;
    public int speedPrice;
    public bool dmgMax;
    public bool speedMax;
    void Start()
    {
        summon = GameObject.Find("EnemyMakers").GetComponent<EnemySummoner>();
    }

    void Update()
    {
            attackCurTime += Time.deltaTime;
        if (attackCurTime > attackSpeed)
        {
            attackRange.SetActive(true);
            attackCurTime = 0;
            isAttack = true;
        }
        if (isAttack)
        {
            attackingCurTime += Time.deltaTime;
            if (attackingCurTime > attackingCoolTime)
            {
                attackRange.SetActive(false);
                attackingCurTime = 0;
                isAttack = false;
            }
        }
    }
}
