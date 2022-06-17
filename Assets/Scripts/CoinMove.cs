using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coins cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<Coins>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cc.player.position, cc.spd * Time.deltaTime);
    }
}
