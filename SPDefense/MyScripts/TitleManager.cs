using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    public GameObject guide;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject title;
    void Start()
    {
        title.transform.DOScale(new Vector3(1, 1, 1), 1.5f);
        button1.transform.DOScale(new Vector3(1, 1, 1), 1.5f);
        button2.transform.DOScale(new Vector3(1, 1, 1), 1.5f);
        button3.transform.DOScale(new Vector3(1, 1, 1), 1.5f);
    }


    void Update()
    {
        
    }
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void GameGuideOpen()
    {
        guide.SetActive(true);
    }

    public void GameGuideClose()
    {
        guide.SetActive(false);
    }
}
