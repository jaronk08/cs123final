using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawning : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject[] prefabPU;
    public float SpawnPerSec = 0.5f;

    [Header("Set Dynamically")]
    public float spawnRadius = 10f;

    private void Start()
    {
        Invoke("SpawnPU", 2.5f);
    }

    void SpawnPU()
    {
        //Random indexed Pedestrian from array spawn.
        int index = Random.Range(0, prefabPU.Length);

        //Random position within set radius.
        Vector3 randomPos = new Vector3(0, 0, 0);
        randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPos.y = 0.69f;
        randomPos.x = randomPos.x - 2;
        randomPos.z = randomPos.z - 16 + 38;

        //Instantiate & Invoke.
        GameObject go = Instantiate<GameObject>(prefabPU[index], randomPos, Quaternion.identity);
        Invoke("SpawnPU", 1f / SpawnPerSec);
    }
}
