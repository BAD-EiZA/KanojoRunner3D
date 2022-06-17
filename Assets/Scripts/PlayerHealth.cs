using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 90;
    public int currentHealth;
    public Slider healthSlider;
    bool isDead;
    bool damaged;
    public GameManager gm;
    private BetaCharController bcc;
    private GameObject pl;
    public RoadSpawner rs;
    public ObsSpawn obs;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        anim = pl.GetComponent<Animator>();
        gm = GetComponent<GameManager>();

        bcc = pl.GetComponent<BetaCharController>();
        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        damaged = false;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        //mengurangi health
        currentHealth -= amount;

        //Merubah tampilan dari health slider
        healthSlider.value = currentHealth;

        anim.SetTrigger("Hurt");

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void TakeHealth(int amount)
    {
        damaged = true;

        //mengurangi health
        currentHealth += amount;

        //Merubah tampilan dari health slider
        healthSlider.value = currentHealth;


    }
    void Death()
    {
        isDead = true;


        //mentrigger animasi Die
        anim.SetTrigger("Die");

        //Memainkan suara ketika mati
        gm.GameOver();

        //mematikan script player movement
        bcc.enabled = false;
        rs.enabled = false;
        obs.enabled = false;


        //mematikan script player shooting

    }
}
