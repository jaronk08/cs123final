using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catHealth : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int health = 4;

    [Header("Set Dynamically")]
    private GameObject lastTriggerGo = null;



    // Start is called before the first frame update
    void Start()
    {
        
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

            }
            Destroy(go);
        }
    }
}
