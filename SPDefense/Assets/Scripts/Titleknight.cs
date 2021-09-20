using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titleknight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("isTitle", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
