using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BulletMaker : MonoBehaviour
{
    public GMR gm;
    public GameObject player;
    public List<GameObject> bullets;
    public GameObject bulletPrefab;
    public GameObject effect;
    public UIManager UI;
    public float curTIme;
    public float playerAttackSpeed;
    public int bulletCnt;

    public Vector2 oldPos;
    public Vector3 nowPoint;
    public float moveSpeed;

    public Vector2 touchPos;
    public Vector3 touchDir;
    public float newPosZ;

    public CameraPosing cameraPos;
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
        for (int i = 0; i < 65; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            bullet.name = "Bullet";
            bullet.GetComponent<Bullet>().startPos = transform;
            bullet.SetActive(false);
            bullets.Add(bullet);
            
        }
    }

    void Update()
    {
        if (gm.mode == GMR.PLAYERMODE.Attack)
        {
            if (Input.touchCount > 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    player.GetComponent<Player>().isAttack = true;
                    if (player.GetComponent<Player>().isAttack)
                        curTIme += Time.deltaTime;
                    if (curTIme >= playerAttackSpeed && player.GetComponent<Player>().isAttack && gm.playerMP > 0)
                    {
                        bullets[bulletCnt].transform.rotation = transform.rotation;
                        bullets[bulletCnt].SetActive(true);
                        Instantiate(effect, transform.position, transform.rotation);
                        cameraPos.isAttack3 = true;
                        curTIme = 0;
                        if (!UI.isDoubleShot && !UI.isTripleShot)
                        {
                            gm.playerMP -= 1f;
                        }
                        else if (UI.isDoubleShot && !UI.isTripleShot)
                        {
                            gm.playerMP -= 0.5f;
                        }
                        else if (UI.isDoubleShot && UI.isTripleShot)
                        {
                            gm.playerMP -= 0.33333333333f;
                        }
                        bulletCnt++;
                    }
                }
            }
            else
            {
                curTIme = 0;
                player.GetComponent<Player>().isAttack = false;
            }
            if (bulletCnt == 65)
                bulletCnt = 0;
        } 

        /*if (gm.mode == GMR.PLAYERMODE.Attack)
        {
            if (Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
            {
                Vector2 dir = (Input.GetTouch(0).position - new Vector2(transform.position.x, transform.position.z)).normalized;
                nowPoint = new Vector3(dir.x, 0.25f, dir.y);
                transform.LookAt(nowPoint);
            }
        }*/
    }
}
