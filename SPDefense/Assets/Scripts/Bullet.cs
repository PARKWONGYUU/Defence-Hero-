using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Transform startPos;
    public float curTIme;
    public float coolTime;
    public GameObject effect;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
        curTIme += Time.deltaTime;
        if(curTIme >= coolTime)
        {
            gameObject.SetActive(false);
            transform.position = startPos.position;
            curTIme = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "FlyEnemy")
        {
            Instantiate(effect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            transform.position = startPos.position;
            curTIme = 0;
        }
    }
}
