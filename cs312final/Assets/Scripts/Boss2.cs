using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public Main main;
    public EnemySpawning S;
    [Header("Set in Inspector")]
    public int health = 8;
    public int enemyScore = 10;

    public static bool dead = false;
    // Start is called before the first frame update
    private void Start()
    {
        S = FindObjectOfType<EnemySpawning>();
        main = FindObjectOfType<Main>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;

        if (go.tag == "Projectile")
        {
            if (health > 0)
            {
                health--;
                Destroy(go);
            }
            else
            {
                Destroy(gameObject);
                Destroy(go);
                S.SetSpawnRate(2f);
                dead = true;
                if (main != null)
                {
                    main.AddScore(enemyScore);
                }
            }

        }
    }
}
