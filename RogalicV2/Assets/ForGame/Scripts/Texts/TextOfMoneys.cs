using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextOfMoneys : MonoBehaviour
{
    private TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = "Money : " + PlayerPrefs.GetInt("MoneyTOPDOWN");
    }

}
