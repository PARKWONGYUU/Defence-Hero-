using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMonsterController : MonoBehaviour
{
    public GameObject eMaker;
    public GameObject bossMaker;
    public GameObject hyperJammer;
    public GameObject hpBar;
    public Transform startPos;
    public Transform goal;
    public GMR gm;
    public UIManager UI;
    public float enemyHP;
    public float maxEnemyHP;
    public int bulletDmg;
    public float xSpeed = 10;
    public Animator anim;
    public Animator anim2;
    public float deadCurTIme;
    public float deadCoolTime = 3f;
    public float attackCurTime;
    public float attackCoolTime = 1f;
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
        goal = GameObject.Find("EnemyGoal").GetComponent<Transform>();
    }

    void Update()
    {
        hpBar.transform.localScale = new Vector3(enemyHP / maxEnemyHP, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
        if (enemyHP > 0)
        {
            transform.Translate(xSpeed * Time.deltaTime, 0, 0);
        }
        if (enemyHP <= 0 && gameObject.name != "Boss")
        {
            if (GetComponent<BoxCollider>().center.y < 9)
            {
                GetComponent<BoxCollider>().center += new Vector3(0, 10, 0);
            }
            enemyHP = 0f;
            deadCurTIme += Time.deltaTime;
            transform.Translate(0, xSpeed * Time.deltaTime / 2, 0);
            anim.SetBool("isDead", true);
            anim2.SetBool("isDead", true);
            eMaker.GetComponent<EnemyMaker>().activeEnemys.Remove(gameObject);
            if (hyperJammer != null)
            {
                hyperJammer.GetComponent<HyperJammer>().passEnemys.Remove(gameObject);
            }
            if (deadCurTIme >= deadCoolTime)
            {
                GetComponent<BoxCollider>().center -= new Vector3(0, 10, 0);
                anim.SetBool("isDead", false);
                anim2.SetBool("isDead", false);
                gameObject.SetActive(false);
                transform.position = startPos.position;
                deadCurTIme = 0;
            }
        }
        if (enemyHP <= 0 && gameObject.name == "Boss")
        {
            if (GetComponent<BoxCollider>().center.y < 9)
            {
                GetComponent<BoxCollider>().center += new Vector3(0, 10, 0);
            }
            enemyHP = 0f;

            gm.bossDetected = false;
            deadCurTIme += Time.deltaTime;
            transform.Translate(0, xSpeed * Time.deltaTime / 2, 0);
            anim.SetBool("isDead", true);
            anim2.SetBool("isDead", true);
            bossMaker.GetComponent<BossMaker>().activeEnemys.Remove(gameObject);
            hyperJammer.GetComponent<HyperJammer>().passEnemys.Remove(gameObject);
            if (deadCurTIme >= deadCoolTime)
            {
                GetComponent<BoxCollider>().center -= new Vector3(0, 10, 0);
                anim.SetBool("isDead", false);
                anim2.SetBool("isDead", false);
                gameObject.SetActive(false);
                transform.position = startPos.position;
                deadCurTIme = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EnemyGoal" && gameObject.name != "Boss")
        {
            eMaker.GetComponent<EnemyMaker>().activeEnemys.Remove(gameObject);
            gameObject.SetActive(false);
            transform.position = startPos.position;
            gm.playerHP -= 1f;
        }
        if (gameObject.name == "Boss" && other.gameObject.name == "EnemyGoal")
        {
            bossMaker.GetComponent<BossMaker>().activeEnemys.Remove(gameObject);
            gameObject.SetActive(false);
            transform.position = startPos.position;
            gm.playerHP -= 30f;
        }
        if (other.gameObject.tag == "Bullet")
        {
            enemyHP -= UI.bulletDmg;
        }
    }
}

