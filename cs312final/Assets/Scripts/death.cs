using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public Main main;
    private bool hasPassed = false;
    [Header("Set in Inspector")]
    public int enemyScore = 10;
    public int health = 8;
    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPassed==false && Main.scoreTotal > 150)
        {
            hasPassed = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go=other.gameObject;

        if (go.tag == "Projectile")
        {
           if(health>0)
            {
                health--;
                Destroy(go);
            }
            else
            {
                Destroy(gameObject);
                Destroy(go);
                if (main != null)
                {
                    main.AddScore(enemyScore);
                }
            }

        }
    }
}
