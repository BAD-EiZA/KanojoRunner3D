using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{

    [Header("Navigation Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private Text priceText;

    [Header("Car Attributes")]
    [SerializeField] private int[] carPrices;
    private int CurChara;


    private void Start()
    {

        CurChara = SaveManager.instance.CurChara;
        SelectCar(CurChara);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);

        UpdateUI();
    }
    private void UpdateUI()
    {
        //If current car unlocked show the play button
        if (SaveManager.instance.charaunlock[CurChara])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        //If not show the buy button and set the price
        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = carPrices[CurChara] + "$";
        }
    }

    private void Update()
    {
        //Check if we have enough money
        if (buy.gameObject.activeInHierarchy)
            buy.interactable = (SaveManager.instance.money >= carPrices[CurChara]);
    }

    public void ChangeCar(int _change)
    {
        CurChara += _change;

        if (CurChara > transform.childCount - 1)
            CurChara = 0;
        else if (CurChara < 0)
            CurChara = transform.childCount - 1;

        SaveManager.instance.CurChara = CurChara;
        SaveManager.instance.Save();
        SelectCar(CurChara);
    }
    public void BuyCar()
    {
        SaveManager.instance.money -= carPrices[CurChara];
        SaveManager.instance.charaunlock[CurChara] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }
}