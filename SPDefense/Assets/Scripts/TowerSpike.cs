using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpike : MonoBehaviour
{
    public float upSpike;
    public float downSpike;

    public Animator spikeTrapAnim;

    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }
    void Update()
    {
        downSpike = transform.parent.GetComponentInParent<Tower>().attackSpeed;
    }

    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        GetComponent<AudioSource>().enabled = true;
        //wait 2 seconds;
        yield return new WaitForSeconds(upSpike);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        GetComponent<AudioSource>().enabled = false;
        //wait 2 seconds;
        yield return new WaitForSeconds(downSpike - 0.1f);
        //Do it again;
        StartCoroutine(OpenCloseTrap());
    }
}
