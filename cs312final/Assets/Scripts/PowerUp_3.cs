using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_3 : MonoBehaviour
{
    public int powerHealth = 3;
    public int newHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            newHealth = StickFigure.S.health + powerHealth;
            StickFigure.S.PowerUp3(newHealth);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
