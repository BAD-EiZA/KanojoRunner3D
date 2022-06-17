using UnityEngine;

public class PlayerList : MonoBehaviour
{
    [SerializeField] private GameObject[] charamodel;

    private void Awake()
    {
        ChooseChara(SaveManager.instance.CurChara);
    }
    private void ChooseChara(int _index)
    {
        Instantiate(charamodel[_index], transform.position, Quaternion.identity, transform);
    }
}