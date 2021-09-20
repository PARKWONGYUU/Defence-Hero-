using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public UIManager UI;
    public Slider bgmVolume;
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        GetComponent<AudioSource>().volume = bgmVolume.value;
    }
}
