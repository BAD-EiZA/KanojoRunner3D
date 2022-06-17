using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObs : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject destroyobj;
    // Start is called before the first frame update
    void Start()
    {
        destroyobj = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if ((transform.position.z - destroyobj.transform.position.z) < -100f)
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(destroyobj, 80);
    }
}
