using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormTower : MonoBehaviour
{
    public float curTime;
    public float coolTime = 4;
    public float stopTime = 2;
    public GameObject effect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        
        if(curTime >= stopTime && !effect.activeInHierarchy)
        {
            curTime = 0;
            effect.SetActive(true);
        }
        else if (curTime >= coolTime && effect.activeInHierarchy)
        {
            curTime = 0;
            effect.SetActive(false);
        }
    }
}
