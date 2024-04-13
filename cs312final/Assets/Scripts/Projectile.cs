using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float lifeTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
