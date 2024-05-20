using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float damage;
    public float destroyTime;
    public float speed;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "enemy")
            {
                if (collision.GetComponent<mobController>().isLife)
                {
                    collision.GetComponent<TakeDamage>().GetDamage(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
