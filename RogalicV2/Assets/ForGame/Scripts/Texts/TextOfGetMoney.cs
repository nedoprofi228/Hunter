using TMPro;
using UnityEngine;

public class TextOfMoney : MonoBehaviour
{
    private TMP_Text text;
    private bool _moneyIsSaved = false;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        _moneyIsSaved = false;
    }

    private void Update()
    {
        text.text = "Money : " + Data.GetMoney;
        if(Data.Kills <= 0 && !_moneyIsSaved)
        {
            _moneyIsSaved = true;
            Data.Money += Data.GetMoney;
            PlayerPrefs.SetInt("MoneyTOPDOWN", Data.Money);
        }
    }


}
