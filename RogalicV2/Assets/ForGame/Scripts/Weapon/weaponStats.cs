
using UnityEngine;

[CreateAssetMenu(fileName = "new weaponStatsData")]
public class weaponStatsData : ScriptableObject
{
    public AudioClip clip;

    public int countAmmo;

    public float cdFire = 0.3f;
    public float coldown;
}
