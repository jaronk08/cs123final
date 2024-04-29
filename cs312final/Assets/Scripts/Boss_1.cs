using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    public Transform player;
    public GameObject missilePrefab;
    public float moveSpeed = 2f;
    public float shootInterval = 2f;
    public float missileSpeed = 5f;

    private float shootTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = shootInterval;
    }

    void Update()
    {
        Vector3 playerDirection = (player.position - transform.position).normalized;
        transform.LookAt(player);

        // Shoot homing missiles
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            ShootMissile();
            shootTimer = shootInterval;
        }
    }

    void ShootMissile()
    {
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<ProjectileHoming>().SetTarget(player, missileSpeed);
    }
}
