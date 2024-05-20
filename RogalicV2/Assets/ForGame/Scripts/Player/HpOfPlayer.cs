using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace Player
{
    public class HpOfPlayer : MonoBehaviour
    {
        public Image[] hearts;
        public Sprite hasHp;
        public Sprite notHasHp;
        void Start()
        {
        }

        void Update()
        {

        }
        private void FixedUpdate()
        {
            CheckHp();
        }
        void CheckHp()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i >= PlayerController.hp)
                {
                    hearts[i].sprite = notHasHp;
                }
                else
                {
                    hearts[i].sprite = hasHp;
                }

            }
        }
    }
}
