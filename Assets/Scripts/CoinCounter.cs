using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text txt;

    private void Awake()
    {
        txt = GetComponent<Text>();
    }
    private void Update()
    {
        txt.text = SaveManager.instance.money + " $";
    }
}