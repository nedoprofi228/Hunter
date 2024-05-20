using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public TMP_Text textScore;
    GameObject player;

    public float speed = 1.0f;
    public float offset = 0;

    public float leftLimit ;
    public float rightLimit ;
    public float bottomLimit ;
    public float topLimit ;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").gameObject;
        transform.position = player.transform.position;
        Data.Kills = 0;
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            -10
            );
        textScore.text = Data.Kills.ToString();
    }
}
