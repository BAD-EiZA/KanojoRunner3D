using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollectableSpace : MonoBehaviour
{
    public List<float> collectlaneX;
    public List<float> collectjumpX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetLane()
    {
        if (collectlaneX == null || collectlaneX.Count < 1)
        {
            return -1f;
        }
        return collectlaneX[Random.Range(0, collectlaneX.Count)];
    }

    public float GetJump()
    {
        if (collectjumpX == null || collectjumpX.Count < 1)
        {
            return -1f;
        }
        return collectjumpX[Random.Range(0, collectjumpX.Count)];
    }
}
