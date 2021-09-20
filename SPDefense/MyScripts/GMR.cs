using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMR : MonoBehaviour
{
    public int stageNum = 0;
    public bool stageStart;
    public bool stageEnd;
    public float stageCurTime;
    public float stageCoolTime;
    public float firstStageCoolTime;
    public int gold = 1000;
    public int jewelry = 0;
    public float playerHP = 50;
    public float playerMP = 100;
    public float maxHP = 50;
    public float maxMP = 100;
    public Camera cameraPos;
    public float mpRegen = 1f;
    public float regenCurTime;
    public float regenCoolTime = 0.125f;
    public bool bossDetected;
    public enum PLAYERMODE
    {
        Create,
        Attack,
        Road,
        Dead
    }
    public PLAYERMODE mode;
    public List<EnemyMaker> eMakers;
    public UIManager UI;
    
    void Start()
    {
        Camera.main.transform.position = new Vector3(-2, 25, 0);
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        mode = PLAYERMODE.Road;

        for (int i = 0; i < 10; i++)
        {
            eMakers.Add(GameObject.Find(string.Format("EnemyMaker_{0}", i)).GetComponent<EnemyMaker>());
        }
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMP < maxMP)
        {
            regenCurTime += Time.deltaTime;
            if (regenCurTime >= regenCoolTime)
            {
                playerMP += mpRegen;
                regenCurTime = 0;
            }
        }
        if (mode != PLAYERMODE.Dead)
        {
            if (stageEnd == true && mode != PLAYERMODE.Road && stageNum == 0)
            {
                stageCurTime += Time.deltaTime;
                if (stageCurTime >= firstStageCoolTime)
                {
                    stageStart = true;
                    stageEnd = false;
                    stageNum++;
                    stageCurTime = 0;
                    UI.stageText.GetComponent<Text>().text = "Stage " + stageNum.ToString();
                    UI.stageTextOn = true;
                }
            }
            if (stageEnd == true && mode != PLAYERMODE.Road && stageNum > 0)
            {
                stageCurTime += Time.deltaTime;
                if (stageCurTime >= stageCoolTime)
                {
                    stageStart = true;
                    stageEnd = false;
                    stageNum++;
                    stageCurTime = 0;
                    UI.stageText.GetComponent<Text>().text = "Stage " + stageNum.ToString();
                    UI.stageTextOn = true;
                }
            }
            if (playerHP <= 0)
            {
                mode = PLAYERMODE.Dead;
            }
            switch (mode)
            {
                case PLAYERMODE.Attack:
                    break;

                case PLAYERMODE.Create:
                    break;
                case PLAYERMODE.Dead:
                    Camera.main.transform.rotation = Quaternion.Euler(new Vector3(-100, 0, 0));
                    UI.gameOver.SetActive(true);
                    if(UI.createUI)
                        UI.createUI.SetActive(false);
                    if (UI.attackUI)
                        UI.attackUI.SetActive(false);
                    for (int i = 0; i < GameObject.FindGameObjectsWithTag("Tower").Length; i++)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Tower")[i]);
                    }
                    for (int i = 0; i < GameObject.FindGameObjectsWithTag("Item").Length; i++)
                    {
                        Destroy(GameObject.FindGameObjectsWithTag("Item")[i]);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
