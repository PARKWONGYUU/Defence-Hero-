using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().enemyHP -= transform.parent.GetComponentInParent<Tower>().attackDmg;
        }
        else if(other.gameObject.tag == "FlyEnemy")
        {
            other.GetComponent<FlyMonsterController>().enemyHP -= transform.parent.GetComponentInParent<Tower>().attackDmg;
        }
    }
}
