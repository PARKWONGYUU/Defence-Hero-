using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour
{
    float oldDistance = 0f;       // ��ġ ���� �Ÿ��� �����մϴ�.
    float cameraFOV = 60f;     // ī�޶��� FieldOfView�� �⺻���� 60���� ���մϴ�.
    public Vector2 oldPos;
    public Vector3 nowPoint;
    public float moveSpeed;
    public GMR gm;
    public Text testt;
    public UIManager UI;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GMR>();

        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    void Update()
    {
        CheckTouch();
    }

    void CheckTouch()
    {
        if (gm.mode == GMR.PLAYERMODE.Create)
        {
            if (Input.touchCount > 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && !EventSystem.current.IsPointerOverGameObject())
                {
                    float distance;
                    float nowDistance;

                    if (!UI.onItemUI && !UI.onTowerUI)
                    {
                        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
                        {
                            oldPos = Input.GetTouch(0).position;
                        }
                        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
                        {
                            Vector2 dir = (Input.GetTouch(0).position - oldPos).normalized;
                            nowPoint = new Vector3(dir.x, 0, dir.y);
                            Camera.main.transform.position -= nowPoint * moveSpeed * Time.deltaTime;
                            oldPos = Input.GetTouch(0).position;
                        }

                        if (Input.touchCount == 2 && (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved))
                        {
                            distance = (Input.touches[0].position - Input.touches[1].position).sqrMagnitude;
                            nowDistance = (distance - oldDistance) * 0.01f;
                            cameraFOV -= nowDistance;
                            cameraFOV = Mathf.Clamp(cameraFOV, 30.0f, 60.0f);
                            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraFOV, Time.deltaTime * 5);
                            oldDistance = distance;
                        }
                    }
                }
            }
        }
    }
}
