using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawn : MonoBehaviour
{
    private int initamaount = 5;
    private int spawninter = 11;
    private int lastspawnZ = 22;
    private int spawnamount = 6;
    public List<GameObject> obstacles;
    public GameObject coins;

    public GameObject enemys;
    public GameObject pwerup;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < initamaount; i++)
        {
            SpawnObstacle();
        }

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void SpawnObstacle()
    {
        for (int i = 0; i < spawnamount; i++)
        {
            lastspawnZ += spawninter;
            if (Random.Range(0, 4) == 0)
            {
                GameObject obstaclez = obstacles[Random.Range(0, obstacles.Count)];
                Instantiate(obstaclez, new Vector3(0, -0.25f, lastspawnZ), obstaclez.transform.rotation);
                if (Random.Range(0, 2) == 1)
                {
                    ObstacleCollectableSpace space = obstaclez.GetComponent<ObstacleCollectableSpace>();
                    Instantiate(coins, new Vector3(space.GetLane(), 0, lastspawnZ + 1.5f), coins.transform.rotation);
                }

                if (Random.Range(0, 15) == 1)
                {
                    ObstacleCollectableSpace space = obstaclez.GetComponent<ObstacleCollectableSpace>();
                    Instantiate(enemys, new Vector3(space.GetLane(), 0, lastspawnZ + Random.Range(0f, 11f)), enemys.transform.rotation);
                }

                if (Random.Range(0, 20) == 1)
                {
                    ObstacleCollectableSpace space = obstaclez.GetComponent<ObstacleCollectableSpace>();
                    Instantiate(pwerup, new Vector3(space.GetLane(), 0, lastspawnZ + 1.5f), pwerup.transform.rotation);
                }
            }
            else
            {
                if (Random.Range(0, 2) == 1)
                {
                    Instantiate(coins, new Vector3(0, 0, lastspawnZ + 1.5f), coins.transform.rotation);
                }
                if (Random.Range(0, 15) == 1)
                {
                    Instantiate(enemys, new Vector3(Random.Range(-4f, 4f), 0, lastspawnZ + Random.Range(0f, 11f)), enemys.transform.rotation);
                }
                if (Random.Range(0, 20) == 1)
                {

                    Instantiate(pwerup, new Vector3(0, 0, lastspawnZ + 1.5f), pwerup.transform.rotation);
                }

            }
        }
    }
}
