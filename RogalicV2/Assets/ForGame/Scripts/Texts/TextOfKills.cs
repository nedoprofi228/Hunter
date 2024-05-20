using System.Collections;
using TMPro;
using UnityEngine;

public class Texts : MonoBehaviour
{
    private TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = "kills : " + Data.Kills;
        StartCoroutine(CountKillsToZero());
    }

    IEnumerator CountKillsToZero()
    {
        yield return new WaitForSeconds(1);
        while (Data.Kills > 0)
        {
            text.text = "kills : " + Data.Kills;
            Data.Kills--;
            Data.GetMoney++;
            yield return new WaitForSeconds(0.3f);
        }
        text.text = "kills : " + Data.Kills;
    }
}
