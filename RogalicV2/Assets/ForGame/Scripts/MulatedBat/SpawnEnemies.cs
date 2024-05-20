using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    System.Random rand = new();
    public List<GameObject> lstOfEnemies = new();
    public List<GameObject> lstOfSpawnPoints = new();

    public static bool spawn = true;
    private float spawnerTime;
    public static float spawnCD = 2;

    public void Start()
    {
        spawn = true;
        spawnerTime = spawnCD;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (spawn && PlayerController.isLive && Time.timeScale > 0)
        {
            if (spawnerTime - 0.01f > 0)
                spawnerTime -= 0.01f;
            Debug.Log("coroutine spawner");
            SpawnInner();
            yield return new WaitForSeconds(spawnerTime);
        }
    }
    public void SpawnInner()
    {
        for (int i = 0; i < lstOfEnemies.Count; i++)
        {
            Instantiate(lstOfEnemies[i], position: GetPos(lstOfSpawnPoints[rand.Next(lstOfSpawnPoints.Count)].transform.position), Quaternion.identity);
        }
    }
    Vector3 GetPos(Vector3 pos) => new Vector3(pos.x, pos.y, 10);
}
