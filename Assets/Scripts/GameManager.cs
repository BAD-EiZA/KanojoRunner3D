using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private int playerCoins = 0;
    public BetaCharController charplayer;
    public Text uiDistance;
    public Text uiCoins;
    public bool doublecoin;
    int distancse;


    public GameObject gameoverui;
    // Start is called before the first frame update
    void Start()
    {
        doublecoin = false;
        player = GameObject.FindGameObjectWithTag("Player");
        charplayer = player.GetComponent<BetaCharController>();
    }

    // Update is called once per frame
    void Update()
    {
        distancse = Mathf.RoundToInt(player.transform.position.z);
        uiDistance.text = distancse.ToString() + "" + "M";
        if (distancse > 1500)
        {
            charplayer.movespd = 20;
            charplayer.anim.SetFloat("RunSpd", 1.2f);
        }
        if (distancse > 2500)
        {
            charplayer.movespd = 30;
            charplayer.anim.SetFloat("RunSpd", 1.3f);
        }
        if (distancse > 3500)
        {
            charplayer.movespd = 35;
            charplayer.anim.SetFloat("RunSpd", 1.5f);
        }
        uiCoins.text = "Coins : " + "" + playerCoins.ToString();
    }

    public void CoinCollect()
    {
        if (doublecoin)
        {
            StartCoroutine(PowDur(15));

        }
        playerCoins += 1;
    }
    IEnumerator PowDur(float duration)
    {
        doublecoin = true;
        playerCoins += 2;
        yield return new WaitForSeconds(duration);
        doublecoin = false;
    }

    public void GameOver()
    {
        SaveManager.instance.money += playerCoins;
        if (SaveManager.instance.distances < distancse)
        {
            SaveManager.instance.distances = distancse;
        }

        gameoverui.SetActive(true);
    }
}
