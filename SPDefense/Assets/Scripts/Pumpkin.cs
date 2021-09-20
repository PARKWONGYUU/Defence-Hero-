using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public Tower tower;
    public Animator pumpkin;
    public GameObject audioSound;
    public float curTime;
    public float coolTime = 1.5f;
    void Start()
    {
        
    }

    void Update()
    {
        if (tower.attackCurTime > tower.attackSpeed - 0.3f)
        {
            pumpkin.SetBool("isAttack", true);
            audioSound.SetActive(true);
        }
        else
        {
            pumpkin.SetBool("isAttack", false);
        }
        if(audioSound)
        {
            curTime += Time.deltaTime;
            if(curTime > coolTime)
            {
                curTime = 0;
                audioSound.SetActive(false);
            }
        }
    }
}
