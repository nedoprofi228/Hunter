using UnityEngine;
using Player;

public class DieEnemy : MonoBehaviour
{

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!PlayerController.isLive)
            Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            gameObject.transform.parent.GetComponent<mobController>().playerInExplotion = true;
            Die();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            gameObject.transform.parent.GetComponent<mobController>().playerInExplotion = false;
        }
    }
   
    public void Die() 
    {
        _anim.SetTrigger("died");
    }
    
}
