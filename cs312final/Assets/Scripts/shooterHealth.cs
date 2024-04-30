using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterHealth : MonoBehaviour
{
    public Main main;
    [Header("Set in Inspector")]
    public int health = 5;
    public int enemyScore = 10;
    [Header("Set Dynamically")]
    private GameObject lastTriggerGo = null;
    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Transform rootT = collision.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        //check for repeat triggers
        if (go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        //check for projectile
        if (go.tag == "Projectile")
        {

            Debug.Log("hit");
            if (health > 0)
            {
                health--;
            }
            else
            {
                Destroy(gameObject);
                if (main != null)
                {
                    main.AddScore(enemyScore);
                }
            }
            Destroy(go);
        }
    }
}
