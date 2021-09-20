using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject testUI;
    public GameObject createUI;
    public GameObject attackUI;
    public GameObject testText;
    public GameObject errorText;
    public GameObject stageText;
    public GameObject towerUI;
    public GameObject itemUI;
    public GameObject playerUI;
    public GameObject upgradeUI;
    public GameObject upgradeUIText;
    public GameObject gameOver;
    public GameObject inGameMenu;
    public GameObject bulletMaker;
    public GameObject doubleShot;
    public GameObject tripleShot;
    public Slider hpBar_Create;
    public Slider hpBar_Attack;
    public Slider mpBar;
    public Text goldText;
    public Text jewelryText;
    public Text dmgPriceText;
    public Text speedPriceText;
    public bool onTowerUI;
    public bool onItemUI;
    public bool onPlayerUI;
    public bool isDoubleShot;
    public bool isTripleShot;
    public GMR gm;
    public CreateManager cm;
    public UpgradeManager upm;
    public List<Tower> towerPrefabs;
    public bool stageTextOn;
    public Transform cameraPos;
    public float cameraZoom;
    public int bulletDmg;
    public GameObject menuButton;
    public GameObject status;
    public GameObject towerMenu;
    public GameObject towerButton;
    public GameObject attackButton;
    public GameObject itemButton;
    public GameObject hpBar;
    public GameObject attackHPBar;
    public GameObject attackMPBar;
    public GameObject upgradeMenu;
    public GameObject createButton;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GMR>();
        cm = GameObject.Find("CreateManager").GetComponent<CreateManager>();
        upm = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        menuButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, -100), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (stageTextOn)
        {
            stageText.SetActive(true);
        }
        else
        {
            stageText.SetActive(false);
        }
        if (!upm.tower)
        {
            upgradeUIText.GetComponent<Text>().text = "Select Tower";
        }
        else
        {
            upgradeUIText.GetComponent<Text>().text = upm.tower.name;
            if (!upm.tower.GetComponent<Tower>().dmgMax)
            {
                dmgPriceText.text = "DMG UP" + "\r\n" + upm.dmgPrice + "G";
            }
            else
            {
                dmgPriceText.text = "DMG UP" + "\r\n" + "MAX";
            }
            if (!upm.tower.GetComponent<Tower>().speedMax)
            {
                speedPriceText.text = "SPEED UP" + "\r\n" + upm.speedPrice + "G";
            }
            else
            {
                speedPriceText.text = "SPEED UP" + "\r\n" + "MAX";
            }
        }
        goldText.text = gm.gold.ToString();
        jewelryText.text = gm.jewelry.ToString();
        hpBar_Create.value = gm.playerHP / gm.maxHP;
        hpBar_Attack.value = gm.playerHP / gm.maxHP;
        mpBar.value = gm.playerMP / gm.maxMP;

    }

    public void TowerMenu()
    {
        if (!onItemUI)
        {
            if (onTowerUI == true)
            {
                towerUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 200);
                towerUI.SetActive(false);
                onTowerUI = false;
                cm.towerNum = -1;

            }
            else
            {
                towerUI.SetActive(true);
                towerUI.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-800, -200), 0.3f);
                onTowerUI = true;
            }
        }
        else
        {
            itemUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 200);
            itemUI.SetActive(false);
            onItemUI = false;
            TowerMenu();
        }
    }
    public void itemMenu()
    {
        if (!onTowerUI)
        {
            if (onItemUI == true)
            {
                itemUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 200);
                itemUI.SetActive(false);
                onItemUI = false;
                cm.itemNum = -1;
            }
            else
            {
                itemUI.SetActive(true);
                itemUI.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-800, -200), 0.3f);
                onItemUI = true;
            }
        }
        else
        {
            towerUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 200);
            towerUI.SetActive(false);
            onTowerUI = false;
            itemMenu();
        }
    }
    public void AttackMode()
    {
        createUI.SetActive(false);
        menuButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, -100);
        status.GetComponent<RectTransform>().anchoredPosition = new Vector2(-200, 100);
        towerMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -200);
        towerButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-500, -200);
        attackButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -200);
        itemButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -200);
        hpBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(169, -200);


        attackUI.SetActive(true);
        menuButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, -100), 0.5f);
        status.GetComponent<RectTransform>().DOAnchorPos(new Vector2(100, 100), 0.5f);
        attackHPBar.GetComponent<RectTransform>().DOAnchorPos(new Vector2(169, 150), 0.5f);
        attackMPBar.GetComponent<RectTransform>().DOAnchorPos(new Vector2(169, 50), 0.5f);
        createButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, 100), 0.5f);
        upgradeMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, 300), 0.5f);


        cameraPos.position = Camera.main.transform.position; //기본 카메라 0 25 -15 / 60 0 0
        cameraPos.rotation = Camera.main.transform.rotation;
        cameraZoom = Camera.main.fieldOfView;
        Camera.main.transform.DOMove(new Vector3(-4, 27, 0), 1f);
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        Camera.main.fieldOfView = 60f;
        gm.mode = GMR.PLAYERMODE.Attack;
    }
    public void CreateMode()
    {
        attackUI.SetActive(false);
        menuButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, -100);
        status.GetComponent<RectTransform>().anchoredPosition = new Vector2(-200, 100);
        attackHPBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(169, -100);
        attackMPBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(169, -200);
        createButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, 100);
        upgradeMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, 300);



        createUI.SetActive(true);
        menuButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, -100), 0.5f);
        status.GetComponent<RectTransform>().DOAnchorPos(new Vector2(100, 100), 0.5f);
        towerMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(50, 200), 0.5f);
        towerButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-500, 100), 0.5f);
        attackButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-100, 100), 0.5f);
        itemButton.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-300, 100), 0.5f);
        hpBar.GetComponent<RectTransform>().DOAnchorPos(new Vector2(169, 100), 0.5f);
        Camera.main.transform.DOMove(cameraPos.position, 1f); //기본 카메라 0 30 -10 / 60 0 0
        Camera.main.transform.rotation = cameraPos.rotation;
        Camera.main.fieldOfView = cameraZoom;
        gm.mode = GMR.PLAYERMODE.Create;
    }
    public void GameReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void GoTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void GameExit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        Time.timeScale = 0f;
        cameraPos.position = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(1000, 1000, 1000);
        inGameMenu.SetActive(true);
    }
    public void BackToGame()
    {
        Time.timeScale = 1f;
        Camera.main.transform.position = cameraPos.position;
        inGameMenu.SetActive(false);
    }
    public void PlayerMenu()
    {
        if (onPlayerUI == true)
        {
            playerUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 200);
            playerUI.SetActive(false);
            onPlayerUI = false;

        }
        else
        {
            playerUI.SetActive(true);
            playerUI.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-800, -200), 0.3f);
            onPlayerUI = true;
        }
    }
    public void PlayerPowerUp()
    {
        if (gm.jewelry >= 3)
        {
            bulletDmg += 100;

            gm.jewelry -= 3;
        }
    }
    public void ManaRegenUp()
    {
        if (gm.jewelry >= 2 && gm.mpRegen < 1.2f)
        {
            gm.mpRegen += 0.05f;
            gm.jewelry -= 2;
        }
    }
    public void MaxMpUp()
    {
        if (gm.jewelry >= 1)
        {
            gm.maxMP += 100;
            gm.jewelry -= 1;
        }
    }
    public void DoubleShotUp()
    {
        if (!isDoubleShot && gm.jewelry >= 10)
        {
            isDoubleShot = true;
            bulletMaker.SetActive(false);
            doubleShot.SetActive(true);
            gm.jewelry -= 10;
        }
    }
    public void TripleShotUp()
    {
        if (isDoubleShot && gm.jewelry >= 10 && !isTripleShot)
        {
            isTripleShot = true;
            doubleShot.SetActive(false);
            tripleShot.SetActive(true);
            gm.jewelry -= 10;
        }
    }
}
