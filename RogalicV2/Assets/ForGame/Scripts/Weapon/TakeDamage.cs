using System.Threading.Tasks;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float hp;
    public GameObject animObject;
    private Animator animator;

    private void Start()
    {
        animator = animObject.GetComponent<Animator>();
    }
    public void GetDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            Debug.Log(gameObject.name + "got damage");
        }
        if (hp <= 0)
        {
            Debug.Log("enemy died by take damage");
            animator.SetTrigger("died");
            GetComponent<mobController>().killedByPlayer = true;
        }
    }
}
