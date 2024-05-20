
using UnityEngine;

public class SelectWeapon : MonoBehaviour
{
    public int chooseWeapon;
    public void StayWeapon()
    {
        WeaponSwitch.weaponSwitch = chooseWeapon;
    }
}
