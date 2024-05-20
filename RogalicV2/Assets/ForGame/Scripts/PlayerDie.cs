using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject[] enemies;
    public void Die()
    {
        AnimSelectedWeapon();
    }

    void AnimSelectedWeapon()
    {
        for (int i = 0;i < guns.Length; i++)
        {
            if (i == WeaponSwitch.weaponSwitch)
            {
                guns[i].GetComponent<Animator>().SetTrigger("die");
            }
        }
    }
    
}
