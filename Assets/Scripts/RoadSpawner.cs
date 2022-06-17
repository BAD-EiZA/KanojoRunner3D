using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 60f;
    // Start is called before the first frame update
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }

    }

    // Update is called once per frame
    public void MoveRoad()
    {
        GameObject Mvroad = roads[0];
        roads.Remove(Mvroad);
        float Newz = roads[roads.Count - 1].transform.position.z + offset;
        Mvroad.transform.position = new Vector3(0, 0, Newz);
        roads.Add(Mvroad);

    }
}
