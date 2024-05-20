using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Gun
{
    public class GunAttack : MonoBehaviour
    {
        public Text text;

        private AudioSource src;
        public AudioClip clip;

        private int offsetRotation;
        private float offset = 0;

        public Transform placeForBullets;
        public GameObject bullet;

        public int countAmmo;
        private int currentAmmo;

        public float cdFire = 0.3f;
        public float coldown;

        private void Start()
        {
            src = GetComponent<AudioSource>();
            currentAmmo = countAmmo;
            text.text = $"{currentAmmo}/{countAmmo}";
            StartCoroutine(Coroutine(cdFire, coldown));
        }
  
        IEnumerator Coroutine(float CdFire, float coldownMagazine)
        {
            while (PlayerController.isLive)
            {
                
                if (GunRotation.x != 0 || GunRotation.y != 0)
                {
                    Debug.Log("CdFire");
                    CheckDirection();
                    Fire();
                    text.text = $"{currentAmmo}/{countAmmo}";
                    yield return new WaitForSeconds(CdFire);
                }
                if (currentAmmo <= 0)
                {
                    yield return new WaitForSeconds(coldownMagazine);
                    currentAmmo = countAmmo;
                    text.text = $"{currentAmmo}/{countAmmo}";
                }
                yield return new WaitForSeconds(0.01f);
                
            }
            
        }
            
        void CheckDirection()
        {
            if(!PlayerController.facingRight)
            {
                offsetRotation = 270;
                if (GunRotation.rotationZ < 90 && GunRotation.rotationZ > -90)
                    offset = 0f;
                else if (GunRotation.rotationZ < -90 && GunRotation.rotationZ > -180)
                    offset = 0.15f;
                else
                    offset = 0.2f;
            }
            else
            {
                offsetRotation = 90;
                if (GunRotation.rotationZ > 90)
                    offset = 0.2f;
                else
                    offset = 0;
            }
        }
        void Fire()
        {
            Debug.Log("-Func Fire-");
            if (currentAmmo > 0)
            {
                src.PlayOneShot(clip);
                currentAmmo -= 1;
                Instantiate(bullet, new Vector2(placeForBullets.position.x, placeForBullets.position.y + offset), Quaternion.Euler(0, 0, GunRotation.rotationZ - offsetRotation));
                Debug.Log("Fire!!!");
                if (gameObject.tag == "drob")
                {
                    Instantiate(bullet, new Vector2(placeForBullets.position.x, placeForBullets.position.y + offset), Quaternion.Euler(0, 0, GunRotation.rotationZ - offsetRotation - 3));
                    Instantiate(bullet, new Vector2(placeForBullets.position.x, placeForBullets.position.y + offset), Quaternion.Euler(0, 0, GunRotation.rotationZ - offsetRotation + 3));
                }

            }
        }

    }
}
