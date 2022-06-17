using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    private int initamount = 5;
    private float plotsize = 60f;
    private float xPosleft = -38.25f;
    private float xPosRight = 38.25f;
    private float lastZPos = 15f;
    public List<GameObject> plots;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initamount; i++)
        {
            SpawnPlot();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlot()
    {
        GameObject plotLeft = plots[Random.Range(0, plots.Count)];
        GameObject plotRight = plots[Random.Range(0, plots.Count)];
        float zPos = lastZPos + plotsize;

        Instantiate(plotLeft, new Vector3(xPosleft, 0.025f, zPos), plotLeft.transform.rotation);
        Instantiate(plotRight, new Vector3(xPosRight, 0.025f, zPos), new Quaternion(0, 180, 0, 0));
        lastZPos += plotsize;

    }


}
