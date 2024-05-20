using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdminScript : MonoBehaviour
{
    public Toggle toggle;
    public Slider sliderOfSpawnCd;
    public TMP_Text valueTextOfSpawnCd;

    public void ValueChance()
    {
        _SetCdSpawnCd();
        _UpdateTextValue();
    }
    private void _SetCdSpawnCd()
    {
        SpawnEnemies.spawnCD = sliderOfSpawnCd.value;

    }

    private void _UpdateTextValue()
    {
        valueTextOfSpawnCd.text = sliderOfSpawnCd.value.ToString();
    }

    public void SetAdminGun()
    {
        if (toggle.isOn)
        {
            WeaponSwitch.weaponSwitch = 3;
        }
        else
        {
            WeaponSwitch.weaponSwitch = 0;
            
        }
    }

    public void OnGodeMode()
    {
        if (toggle.isOn)
        {
            PlayerController.godeMode = true;
        }
        else
        {
            PlayerController.godeMode = false;
        }
    }
}
