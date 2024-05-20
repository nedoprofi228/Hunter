using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] public static int weaponSwitch = 0;
    void Start()
    {
        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform gun in transform)
        {
            if (i == weaponSwitch)
            {
                gun.gameObject.SetActive(true);
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
            i++;
        }
    }

}
