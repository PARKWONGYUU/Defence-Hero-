using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemyNav;
    public Transform startPos;
    public Transform goal;
    public GameObject eMaker;
    public GameObject bossMaker;
    public GameObject magma;
    public GameObject sandArea;
    public GameObject hpBar;
    public UIManager UI;
    public GMR gm;
    public float enemyHP;
    public float maxEnemyHP;
    public int bulletDmg;
    public bool onTheMagma;
    public bool onTheSand;
    public float deadCurTime;
    public float deadCoolTime = 3f;
    public float attackCurTime;
    public float attackCoolTime = 1f;
    public Animator anim;
    
    
    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        goal = GameObject.Find("EnemyGoal").GetComponent<Transform>();
    }

    void Update()
    {
        
        if (enemyHP / maxEnemyHP >= 0)
        {
            hpBar.transform.localScale = new Vector3(enemyHP / maxEnemyHP, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
        }


        enemyNav.SetDestination(goal.position);


        if (enemyHP <= 0 && gameObject.name != "Boss")
        {
            if (GetComponent<BoxCollider>().center.y < 9)
            {
                GetComponent<BoxCollider>().center += new Vector3(0, 10, 0);
            }
            enemyHP = 0f;
            anim.SetBool("isDead", true);
            enemyNav.isStopped = true;
            enemyNav.velocity = Vector3.zero;
            if (onTheSand)
            {
               onTheSand = false;
               sandArea.GetComponent<SandArea>().speedDownEnemys.Remove(gameObject);
            }
            eMaker.GetComponent<EnemyMaker>().activeEnemys.Remove(gameObject);
            if (onTheMagma)
            {
                onTheMagma = false;
                magma.GetComponent<Magma>().dmgEnemys.Remove(gameObject);
            }
            deadCurTime += Time.deltaTime;
            
            if (deadCurTime >= deadCoolTime)
            {
                GetComponent<BoxCollider>().center -= new Vector3(0, 10, 0);
                enemyNav.isStopped = false;
                anim.SetBool("isDead", false);
                gameObject.SetActive(false);
                transform.position = startPos.position;
                deadCurTime = 0;
            }
        }
        if(enemyHP <= 0 && gameObject.name == "Boss")
        {
            if (GetComponent<BoxCollider>().center.y < 9)
            {
                GetComponent<BoxCollider>().center += new Vector3(0, 10, 0);
            }
            enemyHP = 0f;
            gm.bossDetected = false;
            anim.SetBool("isDead", true);
            enemyNav.isStopped = true;
            enemyNav.velocity = Vector3.zero;
            deadCurTime += Time.deltaTime;
            if(onTheSand)
            {
                onTheSand = false;
                sandArea.GetComponent<SandArea>().speedDownEnemys.Remove(gameObject);
            }
            bossMaker.GetComponent<BossMaker>().activeEnemys.Remove(gameObject);

            if (onTheMagma)
            {
                onTheMagma = false;
                magma.GetComponent<Magma>().dmgEnemys.Remove(gameObject);
            }
            if (deadCurTime >= deadCoolTime)
            {
                GetComponent<BoxCollider>().center -= new Vector3(0, 10, 0);
                enemyNav.isStopped = false;
                anim.SetBool("isDead", false);
                gameObject.SetActive(false);
                transform.position = startPos.position;
                deadCurTime = 0;
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
        if(other.gameObject.tag == "Bullet")
        {
            enemyHP -= UI.bulletDmg;
        }
    }
}
