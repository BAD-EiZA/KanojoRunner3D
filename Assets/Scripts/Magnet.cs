using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject objmagnet;
    // Start is called before the first frame update
    public void Start()
    {
        objmagnet = GameObject.Find("CoinDetect");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
