using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using DG.Tweening;

public class RoadTestBox : MonoBehaviour
{
    public NavMeshAgent testNav;
    public Transform goal;
    public float curTIme;
    public float coolTime;
    public float errorCurTime;
    public float errorCoolTime;
    public bool testStart;
    public bool error;
    public GMR gm;
    public UIManager UI;
    public GameObject menuButton;
    public GameObject status;
    public GameObject towerMenu;
    public GameObject towerButton;
    public GameObject attackButton;
    public GameObject itemButton;
    public GameObject hpBar;


    void Start()
    {
        testStart = false;
        testNav = GetComponent<NavMeshAgent>();
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (testStart)
        {
            testNav.SetDestination(goal.position);
            curTIme += Time.deltaTime;
            if (curTIme >= coolTime)
            {
                curTIme = 0;
                transform.position = new Vector3(20f, 0.5f, 7f);
                testStart = false;
                UI.testText.SetActive(false);
                UI.errorText.SetActive(true);
                error = true;
                testNav.SetDestination(transform.position);
            }
        }
        if(error)
        {
            errorCurTime += Time.deltaTime;
            if(errorCurTime >= errorCoolTime)
            {
                UI.errorText.SetActive(false);
                error = false;
                errorCurTime = 0;
            }
        }
    }

    public void RoadTestStart()
    {
        UI.testText.SetActive(true);
        testStart = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EnemyGoal")
        {
            UI.testUI.SetActive(false);
            UI.createUI.SetActive(true);
            menuButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, -100), 0.7f);
            status.GetComponent<RectTransform>().DOAnchorPos(new Vector2(100, 100), 0.7f);
            towerMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(50, 200), 0.7f);
            towerButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-500, 100), 0.7f);
            attackButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, 100), 0.7f);
            itemButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-300, 100), 0.7f);
            hpBar.GetComponent<RectTransform>().DOAnchorPos(new Vector2(169, 100), 0.7f);
            Destroy(gameObject);
            gm.mode = GMR.PLAYERMODE.Create;
            Camera.main.transform.position = new Vector3(-5, 25, -15);
            Camera.main.transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));
        }
    }
}
