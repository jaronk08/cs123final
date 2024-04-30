using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    private bool hasPassed = false;
    [Header("Set in Inspector")]
    public int health = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPassed && Main.scoreTotal > 250)
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
            }

        }
    }
}