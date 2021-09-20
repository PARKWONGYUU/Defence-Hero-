using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class RoadCreateManager : MonoBehaviour
{
    public GMR gm;
    public GameObject effect;
    public GameObject cameraPos;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
    }


    void Update()
    {
        if (gm.mode == GMR.PLAYERMODE.Road)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Rock")
                    {
                        cameraPos.GetComponent<CameraPosing>().isAttack2 = true;
                        cameraPos.GetComponent<CameraPosing>().curTime = 0;
                        Instantiate(effect, hit.transform.position + new Vector3(0, 0.5f, 0), hit.transform.rotation);
                        hit.collider.GetComponent<NavMeshObstacle>().carving = false;
                        hit.collider.gameObject.SetActive(false);
                        gm.
                            -= 10;
                    }
                }
            }
        }
    }
}
