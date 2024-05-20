using System.Collections;
using UnityEngine;


namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static bool godeMode = false;

        public GameObject LoseMenu;

        private AudioSource src;
        public static float shieldAfterDamage = 1.5f;
        public static int hp = 3;

        public Joystick joystickWalk;
        public Joystick joystickAim;
        Rigidbody2D rb;

        public static float moveInputX;
        public static float moveInputY;
        public float moveSpeed;
        public static bool facingRight;

        public static bool isLive;

        Animator anim;

        GameObject gun;

        public void Start()
        {
            facingRight = false;
            src = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody2D>();
            anim = GameObject.Find("player").GetComponent<Animator>();
            gun = GameObject.FindGameObjectWithTag("gun");
            hp = 3;
            isLive = true;
        }

        void Update()
        {
            moveInputX = joystickWalk.Horizontal;
            moveInputY = joystickWalk.Vertical;
            if (isLive)
                CheckHp();
        }
        public void FixedUpdate()
        {
            rb.velocity = new Vector2(moveInputX * moveSpeed * Time.deltaTime, moveInputY * moveSpeed * Time.deltaTime);
            Walk();
        }
        void Walk()
        {
            Flip();
            if (moveInputX != 0 || moveInputY != 0)
            {
                anim.SetBool("walk", true);
                if (!src.isPlaying)
                    src.Play();
                
            }
            else
            {
                anim.SetBool("walk", false);
            }
        }
        void Flip()
        {
            if (moveInputX > 0 && !facingRight || moveInputX < 0 && facingRight)
            {
                facingRight = !facingRight;
                transform.localScale *= new Vector2(-1, 1);
                gun.transform.rotation = Quaternion.identity;
            }
        }
        void CheckHp()
        {
            if (shieldAfterDamage > 0)
            {
                shieldAfterDamage -= Time.deltaTime;
            }
            if (hp <= 0)
            {
                StartCoroutine(Coroutine(0.3f));
                anim.SetTrigger("die");
                moveSpeed = 0;
                isLive = false;
                src.Stop();
            }
        }
        IEnumerator Coroutine(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}
