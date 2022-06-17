using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaCharController : MonoBehaviour
{
    private Rigidbody rb;
    public Animator anim;
    public LayerMask groundlayer;
    private SpawnManager spawnmanagers;
    private GameManager gm;

    Magnet mgt;


    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    public float movespd = 10f;
    private GameObject spwnmanag;
    private GameObject cont;
    private Vector3 movess;
    public float jumpf = 4;
    private PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
        cont = GameObject.FindGameObjectWithTag("SpawnManager");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ph = cont.GetComponent<PlayerHealth>();



        gm = cont.GetComponent<GameManager>();
        spawnmanagers = cont.GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        float hMv = Input.GetAxis("Horizontal");
        movess = new Vector3(hMv, 0, 0);
        movess *= movespd;
        transform.Translate(movess * Time.deltaTime);
        transform.Translate(transform.forward * movespd * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded())
        {
            rb.AddForce(Vector3.up * jumpf, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
    }

    bool isgrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpawnRoad"))
        {
            spawnmanagers.SpawnTriggerEntered();
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            gm.CoinCollect();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {

            if (ph.currentHealth > 0)
            {
                ph.TakeDamage(30);
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (ph.currentHealth > 0)
            {
                ph.TakeDamage(60);
            }
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            if (ph.currentHealth < 90)
            {
                ph.TakeHealth(30);
                Destroy(other.gameObject);
            }
            else if (ph.currentHealth > 90)
            {
                ph.currentHealth = 90;
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.CompareTag("CoinUp"))
        {
            gm.doublecoin = true;
            Destroy(other.gameObject);
        }

    }
}
