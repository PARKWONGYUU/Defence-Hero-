using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int dmgPrice;
    public int speedPrice;
    public bool selectTower = false;
    public CreateManager cm;
    public Tower tower;
    public GMR gm;
    public UIManager UI;
    public List<Tower> spikeTowers;
    public List<Tower> thunderTowers;
    public List<Tower> stormTowers;
    public List<Tower> laserTowers;
    public List<Tower> nuclearTowers;
    public List<Tower> tripleShotTowers;

    void Start()
    {
        cm = GameObject.Find("CreateManager").GetComponent<CreateManager>();
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    
    void Update()
    {
        

    }
    public void DmgUpgrade()
    {
        if (selectTower && gm.gold >= dmgPrice)
        {
            gm.gold -= dmgPrice;
            switch (tower.towerNum)
            {
                case 0:
                    spikeTowers[0].attackDmg += spikeTowers[0].upgradeDmg;
                    for (int i = 0; i < spikeTowers.Count - 1; i++)
                    {
                        spikeTowers[i + 1].attackDmg = spikeTowers[i].attackDmg;
                    }
                    break;
                case 1:
                    thunderTowers[0].attackDmg += thunderTowers[0].upgradeDmg;
                    for (int i = 0; i < thunderTowers.Count - 1; i++)
                    {
                        thunderTowers[i + 1].attackDmg = thunderTowers[i].attackDmg;
                    }
                    break;
                case 2:
                    stormTowers[0].attackDmg += stormTowers[0].upgradeDmg;
                    for (int i = 0; i < stormTowers.Count - 1; i++)
                    {
                        stormTowers[i + 1].attackDmg = stormTowers[i].attackDmg;
                    }
                    break;
                case 3:
                    laserTowers[0].attackDmg += laserTowers[0].upgradeDmg;
                    for (int i = 0; i < laserTowers.Count - 1; i++)
                    {
                        laserTowers[i + 1].attackDmg = laserTowers[i].attackDmg;
                    }
                    break;
                case 4:
                    tripleShotTowers[0].attackDmg += tripleShotTowers[0].upgradeDmg;
                    for (int i = 0; i < tripleShotTowers.Count - 1; i++)
                    {
                        tripleShotTowers[i + 1].attackDmg = tripleShotTowers[i].attackDmg;
                    }
                    break;
                case 5:
                    nuclearTowers[0].attackDmg += nuclearTowers[0].upgradeDmg;
                    for (int i = 0; i < nuclearTowers.Count - 1; i++)
                    {
                        nuclearTowers[i + 1].attackDmg = nuclearTowers[i].attackDmg;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public void SpeedUpgrade()
    {
        if (selectTower && gm.gold >= speedPrice)
        {
            switch (tower.towerNum)
            {
                case 0:
                    if (spikeTowers[0].attackSpeed > 0.4f)
                    {
                        gm.gold -= speedPrice;
                        spikeTowers[0].attackSpeed -= spikeTowers[0].upgradeSpeed;
                        for (int i = 0; i < spikeTowers.Count - 1; i++)
                        {
                            spikeTowers[i + 1].attackSpeed = spikeTowers[i].attackSpeed;
                        }
                    }
                    else
                    {
                        tower.speedMax = true;
                    }
                    break;
                case 1:
                    if (thunderTowers[0].attackSpeed > 0.2f)
                    {
                        gm.gold -= speedPrice;
                        gm.gold -= speedPrice;
                        thunderTowers[0].attackSpeed -= thunderTowers[0].upgradeSpeed;
                        for (int i = 0; i < thunderTowers.Count - 1; i++)
                        {
                            thunderTowers[i + 1].attackSpeed = thunderTowers[i].attackSpeed;
                        }
                    }
                    else
                    {
                        tower.speedMax = true;
                    }
                    break;
                case 2:
                    if (stormTowers[0].attackSpeed > 0.2f)
                    {
                        gm.gold -= speedPrice;
                        stormTowers[0].attackSpeed -= stormTowers[0].upgradeSpeed;
                        for (int i = 0; i < stormTowers.Count - 1; i++)
                        {
                            stormTowers[i + 1].attackSpeed = stormTowers[i].attackSpeed;
                        }
                    }
                    else
                    {
                        tower.speedMax = true;
                    }
                    break;
                case 3:
                    if (laserTowers[0].attackSpeed > 0.2f)
                    {
                        gm.gold -= speedPrice;
                        laserTowers[0].attackSpeed -= laserTowers[0].upgradeSpeed;
                        for (int i = 0; i < laserTowers.Count - 1; i++)
                        {
                            laserTowers[i + 1].attackSpeed = laserTowers[i].attackSpeed;
                        }
                    }
                    else
                    {
                        tower.speedMax = true;
                    }
                    break;
                case 4:
                    if (tripleShotTowers[0].attackSpeed > 0.1f)
                    {
                        gm.gold -= speedPrice;
                        tripleShotTowers[0].attackSpeed += tripleShotTowers[0].upgradeSpeed;
                        for (int i = 0; i < tripleShotTowers.Count - 1; i++)
                        {
                            tripleShotTowers[i + 1].attackSpeed = tripleShotTowers[i].attackSpeed;
                        }
                    }
                    else
                    {
                        tower.speedMax = true;
                    }
                    break;
                case 5:
                    if (nuclearTowers[0].attackSpeed > 1.1f)
                    {
                        gm.gold -= speedPrice;
                        nuclearTowers[0].attackSpeed += nuclearTowers[0].upgradeSpeed;
                        for (int i = 0; i < nuclearTowers.Count - 1; i++)
                        {
                            nuclearTowers[i + 1].attackSpeed = nuclearTowers[i].attackSpeed;
                        }
                    }
                    else
                    {
                        tower.speedMax = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public void DestroyTower()
    {
        if (tower)
        {
            
            switch (tower.towerNum)
            {
                case 0:
                    if (spikeTowers.Count > 1)
                    {
                        spikeTowers.Remove(tower.GetComponent<Tower>());
                        Destroy(tower.gameObject);
                        selectTower = false;
                    }
                    break;
                case 1:
                    if (thunderTowers.Count > 1)
                    {
                        thunderTowers.Remove(tower.GetComponent<Tower>());
                        Destroy(tower.gameObject);
                        selectTower = false;
                    }
                    break;
                case 2:
                    if (stormTowers.Count > 1)
                    {
                        stormTowers.Remove(tower.GetComponent<Tower>());
                        Destroy(tower.gameObject);
                        selectTower = false;
                    }
                    break;
                case 3:
                    if (laserTowers.Count > 1)
                    {
                        laserTowers.Remove(tower.GetComponent<Tower>());
                        Destroy(tower.gameObject);
                        selectTower = false;
                    }
                    break;
                case 4:
                    if (tripleShotTowers.Count > 1)
                    {
                        tripleShotTowers.Remove(tower.GetComponent<Tower>());
                        Destroy(tower.gameObject);
                        selectTower = false;
                    }
                    break;
                case 5:
                    if (nuclearTowers.Count > 1)
                    {
                        nuclearTowers.Remove(tower.GetComponent<Tower>());
                        Destroy(tower.gameObject);
                        selectTower = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void DirectionChange()
    {
        if(tower)
        {
            tower.transform.Rotate(0, 90, 0);
        }
    }
}
