using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Gun
{
    public class GunRotation : MonoBehaviour
    {
        public Joystick joystick;
        public static float rotationZ;
        public static float x, y;

        private SpriteRenderer spriteRenderer;
        private GameObject gun;
        void Start()
        {
            CheckGun();
        }

        void Update()
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
        }
        private void FixedUpdate()
        {
            SetRotation();
        }

        void SetRotation()
        {
            if (x == 0f && y == 0f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (!PlayerController.facingRight)
            {
                rotationZ = Mathf.Atan2(y * -1,  x * -1) * Mathf.Rad2Deg;
            }
            else
            { 
                rotationZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            }
            
            if (Mathf.Abs(rotationZ) < 90)
            {
                spriteRenderer.flipY = false;

            }
            else
            {
                spriteRenderer.flipY = true;
            }

            if (!PlayerController.isLive)
            {
                rotationZ = 0;
            }
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
        void CheckGun()
        {
            gun = GameObject.FindGameObjectWithTag("gunTexture");
            if (gun == null)
            {
                Debug.Log("try found drob");
                gun = GameObject.FindGameObjectWithTag("drob");
            }
            if (gun != null)
            {
                Debug.Log("Gun founded => " + gun.name);
                spriteRenderer = gun.GetComponent<SpriteRenderer>();
            }
            else
            {
                Debug.Log("оружие не найдено");
            }
        }
    }
}
