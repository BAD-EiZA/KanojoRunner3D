using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float mvspd = 8f;
    private Rigidbody enemyrb;
    private GameObject players;
    private GameObject spn;
    private PlayerHealth phh;
    private float reactdistance = 50f;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectWithTag("Player");
        spn = GameObject.FindGameObjectWithTag("SpawnManager");
        phh = spn.GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(players.transform.position, transform.position);
        Vector3 lookDirection;
        Vector3 targetpos = new Vector3(players.transform.position.x, players.transform.position.y, players.transform.position.z);

        if (distance <= reactdistance)
        {
            if (distance > 50f)
            {
                targetpos.z += (distance / 2f);
            }
            lookDirection = (targetpos - transform.position).normalized;
            if (phh.currentHealth <= 0)
            {
                enemyrb.AddForce(lookDirection * 0);

            }
            else
            {

                enemyrb.AddForce(lookDirection * mvspd);
            }
        }
        else
        {
            lookDirection = (targetpos - transform.position).normalized;
            enemyrb.AddForce(lookDirection * mvspd * 0);
        }


        if ((transform.position.z - players.transform.position.z) < -10f)
        {
            Destroy(gameObject);
        }
        else if ((transform.position.y - players.transform.position.y) < -50f)
        {
            Destroy(gameObject);
        }



    }
}
