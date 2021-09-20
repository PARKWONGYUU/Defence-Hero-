using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CreateManager : MonoBehaviour
{
    public int towerNum;
    public int itemNum;
    public List<GameObject> towerPrefabs;
    public List<GameObject> itemPrefabs;
    public GMR gm;
    public GameObject tower;
    public UIManager UI;
    public UpgradeManager upm;
    public int towerPrice;
    public int itemPrice;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        upm = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
    }

    void Update()
    {
        if (gm.mode == GMR.PLAYERMODE.Create)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!EventSystem.current.IsPointerOverGameObject() && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //if (!EventSystem.current.IsPointerOverGameObject())
                //{
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider != null)
                        {
                        Debug.Log(hit.collider.gameObject.name);
                        Debug.Log(hit.collider.gameObject.tag);
                            if(hit.collider.gameObject.tag != "Tower" && hit.collider.gameObject.tag != "TowerGround")
                            {
                                if (UI.onTowerUI)
                                {
                                    UI.onTowerUI = false;
                                    UI.towerUI.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-800, 200), 0.3f);
                                    UI.towerUI.SetActive(false);
                                    towerNum = -1;
                                }
                            }
                            if (hit.collider.gameObject.tag != "Ground")
                            {
                                if (UI.onItemUI)
                                {
                                    UI.onItemUI = false;
                                    UI.itemUI.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-800, 200), 0.3f);
                                    UI.itemUI.SetActive(false);
                                    itemNum = -1;
                                }
                            }
                            switch (hit.collider.gameObject.tag)
                            {
                                case "TowerGround":
                                    if (gm.gold >= towerPrice && towerNum >= 0)
                                    {
                                        GameObject tower = Instantiate(towerPrefabs[towerNum], transform.position, transform.rotation) as GameObject;
                                        tower.name = towerPrefabs[towerNum].name;
                                        tower.transform.position = hit.collider.transform.position + new Vector3(0, 1.5f, 0);
                                        tower.transform.rotation = hit.collider.transform.rotation;
                                        switch (towerNum)
                                        {
                                            case 0:
                                                upm.spikeTowers.Add(tower.GetComponent<Tower>());
                                                if (upm.spikeTowers.IndexOf(tower.GetComponent<Tower>()) != 0)
                                                {
                                                    upm.spikeTowers[upm.spikeTowers.IndexOf(tower.GetComponent<Tower>())].attackSpeed = upm.spikeTowers[upm.spikeTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackSpeed;
                                                    upm.spikeTowers[upm.spikeTowers.IndexOf(tower.GetComponent<Tower>())].attackDmg = upm.spikeTowers[upm.spikeTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackDmg;
                                                }
                                                break;
                                            case 1:
                                                upm.thunderTowers.Add(tower.GetComponent<Tower>());
                                                if (upm.thunderTowers.IndexOf(tower.GetComponent<Tower>()) != 0)
                                                {
                                                    upm.thunderTowers[upm.thunderTowers.IndexOf(tower.GetComponent<Tower>())].attackSpeed = upm.thunderTowers[upm.thunderTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackSpeed;
                                                    upm.thunderTowers[upm.thunderTowers.IndexOf(tower.GetComponent<Tower>())].attackDmg = upm.thunderTowers[upm.thunderTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackDmg;
                                                }
                                                break;
                                            case 2:
                                                upm.stormTowers.Add(tower.GetComponent<Tower>());
                                                if (upm.stormTowers.IndexOf(tower.GetComponent<Tower>()) != 0)
                                                {
                                                    upm.stormTowers[upm.stormTowers.IndexOf(tower.GetComponent<Tower>())].attackSpeed = upm.stormTowers[upm.stormTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackSpeed;
                                                    upm.stormTowers[upm.stormTowers.IndexOf(tower.GetComponent<Tower>())].attackDmg = upm.stormTowers[upm.stormTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackDmg;
                                                }
                                                break;
                                            case 3:
                                                upm.laserTowers.Add(tower.GetComponent<Tower>());
                                                if (upm.laserTowers.IndexOf(tower.GetComponent<Tower>()) != 0)
                                                {
                                                    upm.laserTowers[upm.laserTowers.IndexOf(tower.GetComponent<Tower>())].attackSpeed = upm.laserTowers[upm.laserTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackSpeed;
                                                    upm.laserTowers[upm.laserTowers.IndexOf(tower.GetComponent<Tower>())].attackDmg = upm.laserTowers[upm.laserTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackDmg;
                                                }
                                                break;
                                            case 4:
                                                upm.tripleShotTowers.Add(tower.GetComponent<Tower>());
                                                if (upm.tripleShotTowers.IndexOf(tower.GetComponent<Tower>()) != 0)
                                                {
                                                    upm.tripleShotTowers[upm.tripleShotTowers.IndexOf(tower.GetComponent<Tower>())].attackSpeed = upm.tripleShotTowers[upm.tripleShotTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackSpeed;
                                                    upm.tripleShotTowers[upm.tripleShotTowers.IndexOf(tower.GetComponent<Tower>())].attackDmg = upm.tripleShotTowers[upm.tripleShotTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackDmg;
                                                }
                                                break;
                                            case 5:
                                                upm.nuclearTowers.Add(tower.GetComponent<Tower>());
                                                if (upm.nuclearTowers.IndexOf(tower.GetComponent<Tower>()) != 0)
                                                {
                                                    upm.nuclearTowers[upm.nuclearTowers.IndexOf(tower.GetComponent<Tower>())].attackSpeed = upm.nuclearTowers[upm.nuclearTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackSpeed;
                                                    upm.nuclearTowers[upm.nuclearTowers.IndexOf(tower.GetComponent<Tower>())].attackDmg = upm.nuclearTowers[upm.nuclearTowers.IndexOf(tower.GetComponent<Tower>()) - 1].attackDmg;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        gm.gold -= towerPrice;
                                    }
                                    else if (towerNum >= 0)
                                    {
                                        Debug.Log("골드가 부족합니당.");
                                    }
                                    break;
                                case "Ground":
                                    if (gm.gold >= itemPrice && itemNum >= 0)
                                    {
                                        Debug.Log("?");
                                        GameObject item = Instantiate(itemPrefabs[itemNum], transform.position, transform.rotation) as GameObject;
                                        item.name = itemPrefabs[itemNum].name;
                                        item.transform.position = hit.collider.transform.position + new Vector3(0, 1f, 0);
                                        item.transform.rotation = hit.collider.transform.rotation;
                                        gm.gold -= itemPrice;
                                    }
                                    else if (itemNum >= 0)
                                    {
                                        Debug.Log("골드가 부족합니당.");
                                    }
                                    break;
                                case "Tower":
                                    upm.selectTower = true;
                                    upm.tower = hit.collider.gameObject.GetComponent<Tower>();
                                    upm.dmgPrice = hit.collider.gameObject.GetComponent<Tower>().dmgPrice;
                                    upm.speedPrice = hit.collider.gameObject.GetComponent<Tower>().speedPrice;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
    public void FireTowerMake()
    {
        towerNum = 0;
        towerPrice = 200;
    }
    public void ThunderTowerMake()
    {
        towerNum = 1;
        towerPrice = 200;
    }

    public void StormTowerMake()
    {
        towerNum = 2;
        towerPrice = 500;
    }
    public void LaserTowerMake()
    {
        towerNum = 3;
        towerPrice = 1500;
    }
    public void TripleShotTowerMake()
    {
        towerNum = 4;
        towerPrice = 3500;
    }
    public void NuclearTowerMake()
    {
        towerNum = 5;
        towerPrice = 8000;
    }
    public void Potion()
    {
        if (gm.gold >= 100 && gm.playerHP < gm.maxHP)
        {
            gm.gold -= 100;
            gm.playerHP++;
        }
    }
    public void MPPotion()
    {
        if (gm.gold >= 100 && gm.playerMP < gm.maxMP)
        {
            gm.gold -= 100;
            gm.playerMP += gm.maxMP * 1.1f;
        }
    }
    public void MagmaMake()
    {
        itemNum = 0;
        itemPrice = 1000;
    }
    public void AutoDoorMake()
    {
        itemNum = 1;
        itemPrice = 3500;
    }
    public void SandAreaMake()
    {
        itemNum = 2;
        itemPrice = 1000;
    }
    public void HyperJammerMake()
    {
        itemNum = 3;
        itemPrice = 7500;
    }
}
