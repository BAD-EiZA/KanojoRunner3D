using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject destroyobj;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(destroyobj, 30);
    }
}
