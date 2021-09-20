using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoDoor : MonoBehaviour
{
    public int itemNum = 1;
    public float curTime;
    public float coolTime;
    public bool openTheDoor;
    public GameObject door;
    public Animator TrapDoorAnim;
    void Start()
    {
        TrapDoorAnim = GetComponent<Animator>();
    }
    void Update()
    {
        curTime += Time.deltaTime;
        
        if (curTime > coolTime && openTheDoor)
        {
            door.GetComponent<NavMeshObstacle>().carving = false;
            door.SetActive(false);
            TrapDoorAnim.SetTrigger("close");
            openTheDoor = false;
            curTime = 0;
        }
        else if(curTime > coolTime && !openTheDoor)
        {
            door.GetComponent<NavMeshObstacle>().carving = true;
            door.SetActive(true);
            TrapDoorAnim.SetTrigger("open");
            openTheDoor = true;
            curTime = 0;
        }
    }
}
