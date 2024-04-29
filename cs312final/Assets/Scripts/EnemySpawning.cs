using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public GameObject Boss_1_;


    [Header("Set Dynamically")]
    public float spawnRadius = 10f;
    private float SpawnPerSec = 0.2f;
    

    private void Start()
    {
        Invoke("SpawnEnemies", 2.5f);
        
    }
    

    void SpawnEnemies()
    {
        //Random indexed Pedestrian from array spawn.
        int index = Random.Range(0, prefabEnemies.Length);

        //Random position within set radius.
        Vector3 randomPos = new Vector3(0, 0, 0);
        randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPos.y = 0.69f;
        randomPos.x = randomPos.x - 2;
        randomPos.z = randomPos.z - 16 +38;

        //Instantiate & Invoke.
        GameObject go = Instantiate<GameObject>(prefabEnemies[index], randomPos,Quaternion.identity);
        Invoke("SpawnEnemies", 1f / SpawnPerSec);
    }

    public void SetSpawnRate(float sr)
    {
        SpawnPerSec = sr;
    }

    public void SpawnBoss1()
    {
        Vector3 randomPos = new Vector3(0, 0, 0);
        randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPos.y = 0.69f;
        randomPos.x = randomPos.x - 2;
        randomPos.z = randomPos.z - 16 +38;

        //Instantiate & Invoke.
        GameObject go = Instantiate<GameObject>(Boss_1_, randomPos,Quaternion.identity);
        Invoke("SpawnEnemies", 1f / SpawnPerSec);
    }

}
