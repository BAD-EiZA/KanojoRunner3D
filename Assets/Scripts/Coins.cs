using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Transform player;
    public float spd = 17f;
    CoinMove cv;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cv = gameObject.GetComponent<CoinMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinDetector"))
        {
            cv.enabled = true;
        }
    }
}
