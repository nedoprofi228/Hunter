using UnityEngine;
using Player;

public class EnemyDieEvent : MonoBehaviour
{
    public float maxDistanceOfPush = 1.2f;
    public float coefficientOfPush;
    public float speedOfPush;

    private bool isDied = false;
    public void BeginDie()
    {
        transform.parent.GetComponent<mobController>().isLife = false;
        transform.parent.GetComponent<mobController>().speed = 0;
    }
    public void EndDie()
    {
        if (transform.parent.GetComponent<mobController>().killedByPlayer && !isDied)
        {
            isDied = true;
            Data.Kills += 1;
            Debug.Log("enemy died by player");
        }
        Destroy(transform.parent.gameObject);
    }
    void PushPlayer()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("player");
        float distanceAtPalyerToEnemyX = _player.transform.position.x - transform.parent.gameObject.transform.position.x;
        float distanceAtPalyerToEnemyY = _player.transform.position.y - transform.parent.gameObject.transform.position.y;

        float distanceOfPushX = distanceAtPalyerToEnemyX > 0? maxDistanceOfPush - distanceAtPalyerToEnemyX : -maxDistanceOfPush - distanceAtPalyerToEnemyX;
        float distanceOfPushY = distanceAtPalyerToEnemyY > 0? maxDistanceOfPush - distanceAtPalyerToEnemyY : -maxDistanceOfPush - distanceAtPalyerToEnemyY;

        Vector2 moveTo = new Vector2(_player.transform.position.x + distanceOfPushX * coefficientOfPush, _player.transform.position.y + distanceOfPushY * coefficientOfPush);
        _player.transform.position = Vector3.Lerp(_player.transform.position, moveTo, speedOfPush * Time.deltaTime);
    }
    public void TakeDamage()
    {
        if (transform.parent.GetComponent<mobController>().playerInExplotion && PlayerController.shieldAfterDamage <= 0 && !PlayerController.godeMode)
        {
            PlayerController.hp -= 1;
            PlayerController.shieldAfterDamage = 1f;
            PushPlayer();
        }
    }
}
